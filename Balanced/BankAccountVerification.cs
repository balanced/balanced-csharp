using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balanced
{
    public class BankAccountVerification : Resource
    {
        [JsonIgnore]
        public static string resource_href
        {
            get { return "/bank_account_verifications"; }
        }

        // fields
        [ResourceField]
        public int attempts { get; set; }
        [ResourceField]
        public int attempts_remaining { get; set; }
        [ResourceField]
        public string deposit_status { get; set; }
        [ResourceField]
        public string verification_status { get; set; }

        // attributes
        [ResourceField(field = "bank_account_verifications.bank_account", link = true, serialize = false)]
        public BankAccount bank_account { get; set; }


        public BankAccountVerification() { }

        public BankAccountVerification(Dictionary<string, object> payload) { }

        public static BankAccountVerification Fetch(string href)
        {
            return Resource.Fetch<BankAccountVerification>(href);
        }

        public void Save()
        {
            this.Save<BankAccountVerification>();
        }

        public void Reload()
        {
            this.Reload<BankAccountVerification>();
        }

        public void Confirm(int amount_1, int amount_2)
        {
            Dictionary<string, int> payload = new Dictionary<string, int>();
            payload.Add("amount_1", amount_1);
            payload.Add("amount_2", amount_2);
            Client.Put<BankAccountVerification>(href, Resource.Serialize(payload));
            Reload();
        }

        public class Collection : ResourceCollection<BankAccountVerification>
        {
            public Collection() : base(resource_href) { }
            public Collection(string href) : base(href) { }
        }

        public static ResourceQuery<BankAccountVerification> Query()
        {
            return new ResourceQuery<BankAccountVerification>(resource_href);
        }
    }
}
