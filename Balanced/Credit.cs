using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Balanced
{
    public class Credit : Resource
    {
        [JsonIgnore]
        public static string resource_href
        {
            get { return "/credits"; }
        }

        // fields
        [ResourceField]
        public int amount { get; set; }
        [ResourceField]
        public string appears_on_statement_as { get; set; }
        [ResourceField]
        public string description { get; set; }

        [ResourceField(field = "credits.destination", link = true)]
        public FundingInstrument destination { get; set; }

        [ResourceField(field = "credits.order", link = true)]
        public Order order { get; set; }

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

        [ResourceField(field = "credits.customer", link = true, serialize = false)]
        public Customer customer { get; set; }

        [ResourceField(field = "credits.events", link = true, serialize = false)]
        public Event.Collection events { get; set; }

        [ResourceField(field = "credits.reversals", link = true, serialize = false)]
        public Reversal.Collection reversals { get; set; }


        public Credit() { }

        public Credit(Dictionary<string, object> payload) { }

        public static Credit Fetch(string href)
        {
            return Resource.Fetch<Credit>(href);
        }

        public static Task<Credit> FetchAsync(string href)
        {
            return Resource.FetchAsync<Credit>(href);
        }

        public void Save()
        {
            this.Save<Credit>();
        }

        public Task SaveAsync()
        {
            return this.SaveAsync<Credit>();
        }

        public void Reload()
        {
            this.Reload<Credit>();
        }

        public Task ReloadAsync()
        {
            return this.ReloadAsync<Credit>();
        }

        public Reversal Reverse(Dictionary<string, object> payload)
        {
            return ReverseAsync(payload).GetAwaiter().GetResult();
        }

        public Reversal Reverse()
        {
            return ReverseAsync().GetAwaiter().GetResult();
        }

        public Task<Reversal> ReverseAsync(Dictionary<string, object> payload)
        {
            return reversals.CreateAsync(payload);
        }

        public Task<Reversal> ReverseAsync()
        {
            return ReverseAsync(null);
        }

        public class Collection : ResourceCollection<Credit>
        {
            public Collection() : base(resource_href) { }
            public Collection(string href) : base(href) { }
        }

        public static ResourceQuery<Credit> Query()
        {
            return new ResourceQuery<Credit>(resource_href);
        }
    }
}
