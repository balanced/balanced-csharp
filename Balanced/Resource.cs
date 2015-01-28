using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
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
            SaveAsync<T>().GetAwaiter().GetResult();
        }
        public async Task SaveAsync<T>()
        {
            dynamic res = null;

            if (this.href != null)
            {
                res = await Client.PutAsync<T>(this.href, Serialize(this));
            }
            else
            {
                string href = this.GetType().GetProperty("resource_href").GetValue(this).ToString();
                res = await Client.PostAsync<T>(href, Serialize(this));
            }

            UpdateResource<T>(res);
        }

        public void Unstore()
        {
            Client.Delete(this.href);
        }

        public Task UnstoreAsync()
        {
            return Client.DeleteAsync(this.href);
        }

        public static T Fetch<T>(string href)
        {
            return Client.Get<T>(href);
        }

        public static Task<T> FetchAsync<T>(string href)
        {
            return Client.GetAsync<T>(href);
        }

        public void Reload<T>()
        {
            ReloadAsync<T>().GetAwaiter().GetResult();
        }

        public async Task ReloadAsync<T>()
        {
            dynamic res = await Client.GetAsync<T>(href);
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
