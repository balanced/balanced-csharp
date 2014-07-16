using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Web;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Balanced.Exceptions;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Serialization;

namespace Balanced
{
    class AllPropertiesResolver : DefaultContractResolver
    {
        protected override List<MemberInfo> GetSerializableMembers(Type objectType)
        {
            var properties = objectType.GetProperties()
                .Where(x => x.GetCustomAttributes(typeof(ResourceField), false)
                    .Where(y => ((ResourceField)y).serialize == true).Any())
                .Cast<MemberInfo>()
                .ToList();

            return properties;
        }
    }

    public static class Client
    {
        private static dynamic Op(string path, string method, string payload)
        {
            string url = Balanced.API_URL + path;
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.UserAgent = "balanced-csharp/" + Balanced.VERSION;
            request.Method = method;
            request.ContentType = "application/json;revision=" + Balanced.API_REVISION;
            request.Accept = "application/vnd.api+json;revision=" + Balanced.API_REVISION;
            request.Timeout = 60000;
            request.CachePolicy = new RequestCachePolicy(RequestCacheLevel.BypassCache);
            if (Balanced.API_KEY != null)
            {
                string authorization = Balanced.API_KEY + ":";
                byte[] binaryAuthorization = System.Text.Encoding.UTF8.GetBytes(authorization);
                authorization = Convert.ToBase64String(binaryAuthorization);
                authorization = "Basic " + authorization;
                request.Headers.Add("AUTHORIZATION", authorization);
            }

            if (!String.IsNullOrWhiteSpace(payload))
            {
                byte[] postBytes = Encoding.UTF8.GetBytes(payload);
                request.ContentLength = postBytes.Length;
                Stream dataStream = request.GetRequestStream();
                dataStream.Write(postBytes, 0, postBytes.Length);
                dataStream.Close();
            }

            string responsePayload = string.Empty;
            try
            {
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (var stream = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding(1252)))
                    {
                        responsePayload = stream.ReadToEnd();
                    }
                }
            }
            catch (WebException ex)
            {
                using (var stream = new StreamReader(ex.Response.GetResponseStream()))
                {
                    responsePayload = stream.ReadToEnd();
                }

                HttpWebResponse response = (HttpWebResponse)ex.Response;

                if ((int)response.StatusCode >= 299)
                {
                    if (responsePayload != null)
                        Error(response, responsePayload);
                    else
                        throw new HTTPException(response, responsePayload);
                }
            }

            return responsePayload;
        }

        public static dynamic Get<T>(string path)
        {
            return Get<T>(path, true);
        }

        public static dynamic Get<T>(string path, bool deserialize)
        {
            if (deserialize)
                return Deserialize(Op(path, "GET", null), typeof(T));

            return Op(path, "GET", null);
        }

        public static dynamic Post<T>(string path, string payload)
        {
            return Deserialize(Op(path, "POST", payload), typeof(T));
        }

        public static dynamic Put<T>(string path, string payload)
        {
            return Deserialize(Op(path, "PUT", payload), typeof(T));
        }

        public static void Delete(string path)
        {
            Op(path, "DELETE", null);
        }

        private static string ToQueryString(Dictionary<string, string> queryParams)
        {
            var array = (from key in queryParams.Keys
                         from value in queryParams.Values
                         select string.Format("{0}={1}", HttpUtility.UrlEncode(key), HttpUtility.UrlEncode(value)))
                .ToArray();
            return "?" + string.Join("&", array);
        }

        public static void Error(HttpWebResponse response, string responsePayload)
        {
            if ((int)response.StatusCode == 500)
            {
                throw new HTTPException(response, responsePayload);
            }
            else
            {
                var responseObject = JObject.Parse(responsePayload.ToString());
                var error = responseObject["errors"][0];
                Dictionary<string, object> dict = JsonConvert.DeserializeObject<Dictionary<string, object>>(error.ToString());
                throw new APIException(response, dict);
            }
        }
 
        public static dynamic Deserialize(string payload, Type type)
        {
            return Deserialize(payload, type, null);
        }

        public static dynamic Deserialize(string payload, Type type, dynamic parent)
        {
            var responseObject = JObject.Parse(payload);
            IList<string> keys = responseObject.Properties().Select(p => p.Name).ToList();
            Dictionary<string, string> hyperlinks = responseObject["links"].ToObject<Dictionary<string, string>>();
            Dictionary<string, object> meta = null;
            if (responseObject["meta"] != null)
                meta = responseObject["meta"].ToObject<Dictionary<string, object>>();
            dynamic resource = null;

            foreach (string key in keys)
            {
                // ignore links and meta
                if (key.Equals("links") || key.Equals("meta"))
                {
                    continue;
                }

                resource = responseObject[key][0].ToObject(type);
                resource = HydrateLinks(key, hyperlinks, resource, parent);
            }
            
            return resource;
        }

        public static dynamic HydrateLinks(string key, Dictionary<string, string> hyperlinks, dynamic resource, dynamic parent)
        {
            // Build full links
            Dictionary<string, string> newLinks = new Dictionary<string, string>();

            foreach (KeyValuePair<string, string> entry in hyperlinks)
            {
                string rawLink = entry.Value;
                Regex r = new Regex(@"{(.+?)}");
                Match m = r.Match(rawLink);
                string token = m.Value.ToString();
                string assembledLink = default(string);

                if (token.Contains("."))
                {
                    string theKey = token.Substring(1, token.Length - 2).Substring(token.IndexOf("."));
                    string tokenValue = default(string);

                    try
                    {
                        tokenValue = resource.links[theKey];
                    }
                    catch (KeyNotFoundException)
                    {
                        PropertyInfo property = resource.GetType().GetProperty(theKey);
                        tokenValue = property.GetValue(resource);
                    }

                    if (tokenValue != null)
                    {
                        assembledLink = rawLink.Replace(token, tokenValue);
                    }
                }
                else
                {
                    assembledLink = rawLink;
                }

                newLinks[entry.Key] = assembledLink;
            }

            resource.links = newLinks;

            // Hydrate links
            Type resType = resource.GetType();
            List<PropertyInfo> fields = resType.GetProperties()
                .Where(x => x.GetCustomAttributes(typeof(ResourceField), false)
                    .Where(rf => ((ResourceField)rf).link == true).Any())
                .ToList();

            foreach (PropertyInfo f in fields)
            {
                string fName = f.PropertyType.Name;
                string linkKey = f.GetCustomAttribute<ResourceField>().field;
                string linkHref = null;

                try
                {
                    linkHref = resource.links[linkKey];
                }
                catch (KeyNotFoundException)
                {
                    linkHref = null;
                }
                

                dynamic res = null;

                if (parent != null && ((Resource)parent).href.Equals(linkHref))
                {
                    res = parent;
                }
                else if (linkHref != null)
                {
                    if (fName.Contains("Collection"))
                    {
                        res = Activator.CreateInstance(f.PropertyType, linkHref);
                    }
                    else if (fName.Contains("FundingInstrument")) // TODO: Make this more dynamic
                    {
                        if (linkHref.Contains("/CC"))
                        {
                            res = Deserialize(Client.Get<dynamic>(linkHref, false), typeof(Card), resource);
                        }
                        else if (linkHref.Contains("/BA"))
                        {
                            res = Deserialize(Client.Get<dynamic>(linkHref, false), typeof(BankAccount), resource);
                        }
                    }
                    else
                    {
                        res = Deserialize(Client.Get<dynamic>(linkHref, false), f.PropertyType, resource);
                    }
                }

                f.SetValue(resource, res);
            }

            return resource;
        }
    }
}
