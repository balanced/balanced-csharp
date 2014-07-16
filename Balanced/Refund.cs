using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balanced
{
    public class Refund : Resource
    {
        [JsonIgnore]
        public static string resource_href
        {
            get { return "/refunds"; }
        }

        // fields
        [ResourceField]
        public int amount { get; set; }
        [ResourceField]
        public string description { get; set; }
        
        // attributes
        [ResourceField(serialize = false)]
        public string currency { get; set; }
        [ResourceField(serialize = false)]
        public string status { get; set; }
        [ResourceField(serialize = false)]
        public string transaction_number { get; set; }

        [ResourceField(field = "refunds.debit", link = true, serialize = false)]
        public Debit debit { get; set; }

        [ResourceField(field = "refunds.dispute", link = true, serialize = false)]
        public Dispute dispute { get; set; }

        [ResourceField(field = "refunds.events", link = true, serialize = false)]
        public Event.Collection events { get; set; }

        [ResourceField(field = "refunds.order", link = true, serialize = false)]
        public Order order { get; set; }

        public Refund() { }

        public Refund(Dictionary<string, object> payload) { }

        public static Refund Fetch(string href)
        {
            return Resource.Fetch<Refund>(href);
        }

        public void save()
        {
            this.Save<Refund>();
        }

        public void Reload()
        {
            this.Reload<Refund>();
        }

        public class Collection : ResourceCollection<Refund>
        {
            public Collection() : base(resource_href) { }
            public Collection(string href) : base(href) { }
        }

        public static ResourceQuery<Refund> Query()
        {
            return new ResourceQuery<Refund>(resource_href);
        }
    }
}
