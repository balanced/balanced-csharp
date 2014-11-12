using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balanced
{
    public class Account : Resource
    {
        [JsonIgnore]
        public static string resource_href
        {
            get { return "/accounts"; }
        }

        [ResourceField(field = "accounts.events", link = true, serialize = false)]
        public Event.Collection events { get; set; }

        public static Account Fetch(string href)
        {
            return Resource.Fetch<Account>(href);
        }

        public class Collection : ResourceCollection<Account>
        {
            public Collection() : base(resource_href) { }
            public Collection(string href) : base(href) { }
        }

        public static ResourceQuery<Account> Query()
        {
            return new ResourceQuery<Account>(resource_href);
        }
    }
}
