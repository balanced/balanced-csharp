using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balanced
{
    public class Card : FundingInstrument
    {
        [JsonIgnore]
        public static string resource_href
        {
            get { return "/cards"; }
        }

        // fields
        [ResourceField]
        public Dictionary<string, string> address { get; set; }
        [ResourceField]
        public string cvv { get; set; }
        [ResourceField]
        public int expiration_month { get; set; }
        [ResourceField]
        public int expiration_year { get; set; }
        [ResourceField]
        public string name { get; set; }
        [ResourceField]
        public string number { get; set; }

        // attributes
        [ResourceField(serialize = false)]
        public string avs_postal_match { get; set; }
        [ResourceField(serialize = false)]
        public string avs_result { get; set; }
        [ResourceField(serialize = false)]
        public string avs_result_match { get; set; }
        [ResourceField(serialize = false)]
        public string brand { get; set; }
        [ResourceField(serialize = false)]
        public string category { get; set; }
        [ResourceField(serialize = false)]
        public string cvv_match { get; set; }
        [ResourceField(serialize = false)]
        public string cvv_result { get; set; }
        [ResourceField(serialize = false)]
        public bool is_verified { get; set; }
        [ResourceField(serialize = false)]
        public string type { get; set; }

        [ResourceField(field = "cards.card_holds", link = true, serialize = false)]
        public CardHold.Collection card_holds { get; set; }

        [ResourceField(field = "cards.customer", link = true, serialize = false)]
        public Customer customer { get; set; }

        [ResourceField(field = "cards.debits", link = true, serialize = false)]
        public Debit.Collection debits { get; set; }

        [ResourceField(field = "cards.credits", link = true, serialize = false)]
        public Credit.Collection credits { get; set; }


        public Card() { }

        public Card(Dictionary<string, object> payload) { }

        public static Card Fetch(string href)
        {
            return Resource.Fetch<Card>(href);
        }

        public void Save()
        {
            this.Save<Card>();
        }

        public void Reload()
        {
            this.Reload<Card>();
        }

        public void AssociateToCustomer(Customer customer)
        {
            this.AssociateToCustomer(customer.href);
        }

        public void AssociateToCustomer(string href)
        {
            if (href != null)
            {
                links.Add("customer", href);
                this.Save();
            }
        }

        public CardHold Hold(Dictionary<string, object> payload)
        {
            return card_holds.Create(payload);
        }

        public override Debit Debit(Dictionary<string, object> payload)
        {
            return debits.Create(payload);
        }

        public override Credit Credit(Dictionary<string, object> payload)
        {
            if (credits == null) {
                throw new Exceptions.FundingInstrumentNotCreditable();
            }
            return credits.Create(payload);
        }

        public class Collection : ResourceCollection<Card>
        {
            public Collection() : base(resource_href) { }
            public Collection(string href) : base(href) { }
        }

        public static ResourceQuery<Card> Query()
        {
            return new ResourceQuery<Card>(resource_href);
        }
    }
}
