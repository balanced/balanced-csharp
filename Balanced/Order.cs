using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balanced
{
    public class Order : Resource
    {
        [JsonIgnore]
        public static string resource_href
        {
            get { return "/orders"; }
        }

        // fields
        [ResourceField]
        public string description { get; set; }
        [ResourceField]
        public Dictionary<string, string> delivery_address { get; set; }
        
        // attributes
        [ResourceField(serialize = false)]
        public int amount { get; set; }
        [ResourceField(serialize = false)]
        public int amount_escrowed { get; set; }
        [ResourceField(serialize = false)]
        public string currency { get; set; }

        [ResourceField(field = "orders.buyers", link = true, serialize = false)]
        public Customer.Collection customers { get; set; }

        [ResourceField(field = "orders.credits", link = true, serialize = false)]
        public Credit.Collection credits { get; set; }

        [ResourceField(field = "orders.debits", link = true, serialize = false)]
        public Debit.Collection debits { get; set; }

        [ResourceField(field = "orders.merchant", link = true, serialize = false)]
        public Customer merchant { get; set; }

        [ResourceField(field = "orders.refunds", link = true, serialize = false)]
        public Refund.Collection refunds { get; set; }

        [ResourceField(field = "orders.reversals", link = true, serialize = false)]
        public Refund.Collection reversals { get; set; }


        public Order() { }

        public Order(Dictionary<string, object> payload) { }

        public static Order Fetch(string href)
        {
            return Resource.Fetch<Order>(href);
        }

        public void Save()
        {
            this.Save<Order>();
        }

        public void Reload()
        {
            this.Reload<Order>();
        }

        public Debit DebitFrom(FundingInstrument fi, Dictionary<string, object> options)
        {
            options.Add("order", this.href);
            return fi.Debit(options);
        }

        public Credit CreditTo(BankAccount ba, Dictionary<string, object> options)
        {
            options.Add("order", this.href);
            return ba.Credit(options);
        }

        public class Collection : ResourceCollection<Order>
        {
            public Collection() : base(resource_href) { }
            public Collection(string href) : base(href) { }
        }

        public static ResourceQuery<Order> Query()
        {
            return new ResourceQuery<Order>(resource_href);
        }
    }
}
