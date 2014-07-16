using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balanced
{
    public class Reversal : Resource
    {
        [JsonIgnore]
        public static string resource_href
        {
            get { return "/reversals"; }
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
        public string failure_reason { get; set; }
        [ResourceField(serialize = false)]
        public string failure_reason_code { get; set; }
        [ResourceField(serialize = false)]
        public string status { get; set; }
        [ResourceField(serialize = false)]
        public string transaction_number { get; set; }

        [ResourceField(field = "reversals.credit", link = true, serialize = false)]
        public Credit credit { get; set; }

        [ResourceField(field = "reversals.events", link = true, serialize = false)]
        public Event.Collection events { get; set; }

        [ResourceField(field = "reversals.order", link = true, serialize = false)]
        public Order order { get; set; }

        public Reversal() { }

        public Reversal(Dictionary<string, object> payload) { }

        public static Reversal Fetch(string href)
        {
            return Resource.Fetch<Reversal>(href);
        }

        public void Save()
        {
            this.Save<Reversal>();
        }

        public void Reload()
        {
            this.Reload<Reversal>();
        }

        public class Collection : ResourceCollection<Reversal>
        {
            public Collection() : base(resource_href) { }
            public Collection(string href) : base(href) { }
        }

        public static ResourceQuery<Reversal> Query()
        {
            return new ResourceQuery<Reversal>(resource_href);
        }
    }
}
