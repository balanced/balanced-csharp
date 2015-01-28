using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balanced
{
    public class Account : FundingInstrument
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
        public string type { get; set; }
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

        [ResourceField(field = "accounts.debits", link = true, serialize = false)]
        public Debit.Collection debits { get; set; }

        public Account() { }

        public Account(Dictionary<string, object> payload) { }

        public static Account Fetch(string href)
        {
            return Resource.Fetch<Account>(href);
        }

        public static Task<Account> FetchAsync(string href)
        {
            return Resource.FetchAsync<Account>(href);
        }

        public void Save()
        {
            this.Save<Account>();
        }

        public Task SaveAsync()
        {
            return this.SaveAsync<Account>();
        }

        public void Reload()
        {
            this.Reload<Account>();
        }

        public Task ReloadAsync()
        {
            return this.ReloadAsync<Account>();
        }

        public override Task<Credit> CreditAsync(Dictionary<string, object> payload)
        {
            return credits.CreateAsync(payload);
        }

        public override Task<Debit> DebitAsync(Dictionary<string, object> payload)
        {
            if (this.can_debit == false)
            {
                throw new Exceptions.FundingInstrumentNotDebitable();
            }
            return debits.CreateAsync(payload);
        }

        public Settlement Settle(Dictionary<string, object> payload)
        {
            return settlements.Create(payload);
        }

        public class Collection : ResourceCollection<Account>
        {
            [JsonIgnore]
            public static string href { get; set; }

            public Collection() : base(resource_href) { href = resource_href; }
            public Collection(string pHref) : base(href) { href = pHref; }

            public ResourceQuery<Account> Query()
            {
                return new ResourceQuery<Account>(href);
            }
        }

        public static ResourceQuery<Account> Query()
        {
            return new ResourceQuery<Account>(resource_href);
        }
    }
}
