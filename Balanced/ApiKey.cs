using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balanced
{
    public class ApiKey : Resource
    {
        [JsonIgnore]
        public static string resource_href
        {
            get { return "/api_keys"; }
        }

        [ResourceField]
        public string secret { get; set; }


        public ApiKey() { }

        public static ApiKey Fetch(string href)
        {
            return Resource.Fetch<ApiKey>(href);
        }

        public static Task<ApiKey> FetchAsync(string href)
        {
            return Resource.FetchAsync<ApiKey>(href);
        }

        public void Save()
        {
            Balanced.configure(null);
            this.Save<ApiKey>();
        }

        public Task SaveAsync()
        {
            Balanced.configure(null);
            return this.SaveAsync<ApiKey>();
        }

        public void SaveToMarketplace()
        {
            this.Save<ApiKey>();
        }

        public Task SaveToMarketplaceAsync()
        {
            return this.SaveAsync<ApiKey>();
        }

        public class Collection : ResourceCollection<ApiKey>
        {
            public Collection() : base(resource_href) { }
            public Collection(string href) : base(href) { }
        }

        public static ResourceQuery<ApiKey> Query()
        {
            return new ResourceQuery<ApiKey>(resource_href);
        }
    }
}
