using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balanced
{
    public class Debit : Resource
    {
        [JsonIgnore]
        public static string resource_href
        {
            get { return "/debits"; }
        }

        // fields
        [ResourceField]
        public int amount { get; set; }
        [ResourceField]
        public string appears_on_statement_as { get; set; }
        [ResourceField]
        public string description { get; set; }

        [ResourceField(field = "debits.order", link = true)]
        public Order order { get; set; }

        [ResourceField(field = "debits.source", link = true)]
        public FundingInstrument source { get; set; }

        // attributes
        [ResourceField(serialize = false)]
        public string currency { get; set; }
        [ResourceField(serialize = false)]
        public string failure_reason { get; set; }
        [ResourceField(serialize = false)]
        public string failure_reason_code { get; set; }
        [ResourceField(serialize = false)]
        public string status { get; set; }
        [ResourceField(serialize = false)]
        public string transaction_number { get; set; }

        [ResourceField(field = "debits.customer", link = true, serialize = false)]
        public Customer customer { get; set; }

        [ResourceField(field = "debits.dispute", link = true, serialize = false)]
        public Dispute dispute { get; set; }

        [ResourceField(field = "debits.events", link = true, serialize = false)]
        public Event.Collection events { get; set; }

        [ResourceField(field = "debits.refunds", link = true, serialize = false)]
        public Refund.Collection refunds { get; set; }

        
        public Debit() { }

        public Debit(Dictionary<string, object> payload) { }

        public static Debit Fetch(string href)
        {
            return Resource.Fetch<Debit>(href);
        }

        public void Save()
        {
            this.Save<Debit>();
        }

        public void Reload()
        {
            this.Reload<Debit>();
        }

        public Refund Refund(Dictionary<string, object> payload)
        {
            return refunds.Create(payload);
        }

        public Refund Refund()
        {
            return Refund(null);
        }

        public class Collection : ResourceCollection<Debit>
        {
            public Collection() : base(resource_href) { }
            public Collection(string href) : base(href) { }
        }

        public static ResourceQuery<Debit> Query()
        {
            return new ResourceQuery<Debit>(resource_href);
        }
    }
}
