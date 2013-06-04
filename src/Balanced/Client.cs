using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;

namespace Balanced
{
    public class Client
    {
        public static readonly Encoding Encoding = Encoding.UTF8;
        public static readonly string ContentType = string.Format("application/json");
        public static readonly string AcceptType = "application/json";
        public static Uri BaseUri;
        public static string Secret;
        public static string UserAgent;

        public Client(string baseUri, string secret)
        {
            BaseUri = new Uri(baseUri);
            Secret = secret;
            UserAgent = string.Format("{0}/{1}", Settings.Agent, Settings.Version);
        }

        public Client() : this(Settings.Location, Settings.Secret)
        {
        }

        public IDictionary<string, object> Get(string uri)
        {
            return Request("GET", uri, null, null);
        }

        public IDictionary<string, object> Get(string uri, NameValueCollection query)
        {
            return Request("GET", uri, query, null);
        }

        public IDictionary<string, object> Post(string uri, IDictionary<string, object> data)
        {
            return Request("POST", uri, null, data);
        }

        public IDictionary<string, object> Put(string uri, IDictionary<string, object> data)
        {
            return Request("PUT", uri, null, data);
        }

        public void Delete(string uri)
        {
            Request("DELETE", uri, null, null);
        }

        private IDictionary<string, object> Request(string method, string relativeUri, NameValueCollection query, IDictionary<string, object> data)
        {
            UriBuilder builder = new UriBuilder(BaseUri);
            if (query != null)
            {
                builder.Path = relativeUri;
                builder.Query = query.ToString();
            }
            else
            {
                int i = relativeUri.IndexOf('?');
                if (i == -1)
                {
                    builder.Path = relativeUri;
                }
                else
                {
                    builder.Path = relativeUri.Substring(0, i);
                    builder.Query = relativeUri.Substring(i);
                }
            }
            Uri uri = builder.Uri;

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(uri);
            req.UserAgent = UserAgent;
            req.Method = method;
            req.Accept = AcceptType;
            req.Headers.Add(
                "Accept-Charset",
                Encoding.WebName
            );
            if (Secret != null)
            {
                req.Headers.Add(
                    "Authorization",
                    "Basic " + System.Convert.ToBase64String(Encoding.UTF8.GetBytes(Secret + ":"))
                );
            }

            if (data != null)
            {
                req.ContentType = ContentType;
                string t = Serialize(data);
                byte[] content = Encoding.GetBytes(Serialize(data));
                req.ContentLength = content.Length;
                using (Stream stream = req.GetRequestStream())
                {
                    stream.Write(content, 0, content.Length);
                    stream.Close();
                }
            }

            try
            {
                using (HttpWebResponse resp = req.GetResponse() as HttpWebResponse)
                {
                    using (Stream stream = resp.GetResponseStream())
                    {
                        StreamReader reader = new StreamReader(stream);
                        string body = reader.ReadToEnd();
                        if (body.Length == 0)
                        {
                            return null;
                        }
                        return Deserialize(body);
                    }
                }
            }
            catch (WebException ex)
            {
                Exception error = CreateError(ex);
                if (error == null)
                    throw;
                throw error;
            }
        }

        private Exception CreateError(WebException ex)
        {
            if (ex.Status != WebExceptionStatus.ProtocolError || ex.Response == null)
            {
                return null;
            }
            HttpWebResponse response = (HttpWebResponse) ex.Response;

            string body;
            using (Stream stream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(stream);
                body = reader.ReadToEnd();
            }
            if (response.ContentType != AcceptType || body.Length == 0)
            { 
                return null;
            }
            IDictionary<string, object> data = Deserialize(body);
            return Error.Create(data);
        }

        private string Serialize(IDictionary<string, object> data)
        {
            return SimpleJson.SerializeObject(data);
        }

        private IDictionary<string, object> Deserialize(string raw)
        {
            return (IDictionary<string, object>)SimpleJson.DeserializeObject(raw);
        }

    }
}
