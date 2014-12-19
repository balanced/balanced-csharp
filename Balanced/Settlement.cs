using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balanced
{
    public class Settlement : Resource
    {
        [JsonIgnore]
        public static string resource_href
        {
            get { return "/settlements"; }
        }

        // fields
        [ResourceField]
        public FundingInstrument funding_instrument { get; set; }
        [ResourceField]
        public int amount { get; set; }
        [ResourceField]
        public string description { get; set; }
        [ResourceField]
        public string appears_on_statement_as { get; set; }

        [ResourceField(field = "settlements.destination", link = true)]
        public FundingInstrument destination { get; set; }

        [ResourceField(field = "settlements.source", link = true)]
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

        public Settlement() { }

        public Settlement(Dictionary<string, object> payload) { }

        public static Settlement Fetch(string href)
        {
            return Resource.Fetch<Settlement>(href);
        }

        public void Save()
        {
            this.Save<Settlement>();
        }

        public class Collection : ResourceCollection<Settlement>
        {
            public Collection() : base(resource_href) { }
            public Collection(string href) : base(href) { }
        }

        public static ResourceQuery<Settlement> Query()
        {
            return new ResourceQuery<Settlement>(resource_href);
        }
    }
}
