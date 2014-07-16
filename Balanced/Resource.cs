using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

using Newtonsoft.Json;
using System.Dynamic;
using System.Reflection;

namespace Balanced
{
    public abstract class Resource
    {
        [ResourceField(serialize = false)]
        public string href { get; set; }
        [ResourceField(serialize = false)]
        public string id { get; set; }
        [ResourceField]
        public Dictionary<string, string> links { get; set; }
        [ResourceField]
        public Dictionary<string, string> meta { get; set; }
        [ResourceField(serialize = false)]
        public DateTime created_at { get; set; }
        [ResourceField(serialize = false)]
        public DateTime updated_at { get; set; }

        public Resource() { }

        public void Save<T>()
        {
            dynamic res = null;

            if (this.href != null)
            {
                res = Client.Put<T>(this.href, Serialize(this));
            }
            else
            {
                string href = this.GetType().GetProperty("resource_href").GetValue(this).ToString();
                res = Client.Post<T>(href, Serialize(this));
            }

            UpdateResource<T>(res);
        }

        public void Unstore()
        {
            Client.Delete(this.href);
        }

        public static T Fetch<T>(string href)
        {
            return Client.Get<T>(href);
        }

        public void Reload<T>()
        {
            dynamic res = Client.Get<T>(href);
            UpdateResource<T>(res);
        }

        public void UpdateResource<T>(dynamic res)
        {
            Type resType = this.GetType();
            List<PropertyInfo> fields = resType.GetProperties().ToList();

            foreach (PropertyInfo f in fields)
            {
                string propName = f.Name;
                if (f.Name.Equals("resource_href"))
                    continue;
                PropertyInfo propToCopy = res.GetType().GetProperty(propName);
                object propValue = propToCopy.GetValue(res);

                f.SetValue(this, propValue);
            }
        }

        public static string Serialize(object resource)
        {
            return JsonConvert.SerializeObject(resource,
                new JsonSerializerSettings {
                    NullValueHandling = NullValueHandling.Ignore,
                    ContractResolver = new AllPropertiesResolver()
                });
        }
    }
}
