using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balanced
{
    public class CardHold : Resource
    {
        [JsonIgnore]
        public static string resource_href
        {
            get { return "/card_holds"; }
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
        public DateTime expires_at { get; set; }
        [ResourceField(serialize = false)]
        public string failure_reason { get; set; }
        [ResourceField(serialize = false)]
        public string failure_reason_code { get; set; }
        [ResourceField(serialize = false)]
        public string status { get; set; }
        [ResourceField(serialize = false)]
        public string transaction_number { get; set; }
        [ResourceField(serialize = false)]
        public string voided_at { get; set; }

        [ResourceField(field = "card_holds.card", link = true, serialize = false)]
        public Card card { get; set; }

        [ResourceField(field = "card_holds.debit", link = true, serialize = false)]
        public Debit debit { get; set; }

        [ResourceField(field = "card_holds.debits", link = true, serialize = false)]
        public Debit.Collection debits { get; set; }

        [ResourceField(field = "card_holds.events", link = true, serialize = false)]
        public Event.Collection events { get; set; }


        public CardHold() { }

        public CardHold(Dictionary<string, object> payload) { }

        public static CardHold Fetch(string href)
        {
            return Resource.Fetch<CardHold>(href);
        }

        public void Save()
        {
            this.Save<CardHold>();
        }

        public void Reload()
        {
            this.Reload<CardHold>();
        }

        public Debit Capture(Dictionary<string, object> payload)
        {
            return debits.Create(payload);
        }

        public Debit Capture()
        {
            return this.Capture(null);
        }

        public class Collection : ResourceCollection<CardHold>
        {
            public Collection() : base(resource_href) { }
            public Collection(string href) : base(href) { }
        }

        public static ResourceQuery<CardHold> Query()
        {
            return new ResourceQuery<CardHold>(resource_href);
        }
    }
}
