using System.Threading.Tasks;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

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

        public static Task<CardHold> FetchAsync(string href)
        {
            return Resource.FetchAsync<CardHold>(href);
        }

        public void Save()
        {
            this.Save<CardHold>();
        }

        public Task SaveAsync()
        {
            return this.SaveAsync<CardHold>();
        }

        public void Reload()
        {
            this.Reload<CardHold>();
        }

        public Task ReloadAsync()
        {
            return this.ReloadAsync<CardHold>();
        }

        public Debit Capture(Dictionary<string, object> payload)
        {
            return CaptureAsync(payload).GetAwaiter().GetResult();
        }

        public Debit Capture()
        {
            return CaptureAsync().GetAwaiter().GetResult();
        }

        public Task<Debit> CaptureAsync(Dictionary<string, object> payload)
        {
            return debits.CreateAsync(payload);
        }

        public Task<Debit> CaptureAsync()
        {
            return this.CaptureAsync(null);
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
