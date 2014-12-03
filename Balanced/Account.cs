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

        // fields
        [ResourceField]
        public string description { get; set; }

        // attributes
        [ResourceField(serialize = false)]
        public string account_type { get; set; }
        [ResourceField(serialize = false)]
        public bool can_credit { get; set; }
        [ResourceField(serialize = false)]
        public bool can_debit { get; set; }
        [ResourceField(serialize = false)]
        public string currency { get; set; }
        [ResourceField(serialize = false)]
        public int balance { get; set; }

        [ResourceField(field = "accounts.customer", link = true, serialize = false)]
        public Customer customer { get; set; }

        [ResourceField(field = "accounts.settlements", link = true, serialize = false)]
        public Settlement.Collection settlements { get; set; }

        [ResourceField(field = "accounts.credits", link = true, serialize = false)]
        public Credit.Collection credits { get; set; }


        public Account() { }

        public Account(Dictionary<string, object> payload) { }

        public static Account Fetch(string href)
        {
            return Resource.Fetch<Account>(href);
        }

        public void Save()
        {
            this.Save<Account>();
        }

        public void Reload()
        {
            this.Reload<Account>();
        }


        public Credit Credit(Dictionary<string, object> payload)
        {
            return credits.Create(payload);
        }

        public Settlement Settle(Dictionary<string, object> payload)
        {
            return settlements.Create(payload);
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
