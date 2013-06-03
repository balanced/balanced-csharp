using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balanced
{
    class Debit : Resource
    {
        public DateTime created_at;
        public Dictionary<String, String> meta;
        public int amount;
        public String description;
        public String transaction_number;
        public Card card;
        public String card_uri;
        public String account_uri;
        public Account account;
        public String hold_uri;
        public Hold hold;
        public String refunds_uri;
        public Refund.Collection refunds;
        public class Collection : ResourceCollection<Debit>
        {
            public Collection(String uri) : base(uri) { }
        };
        public Debit() : base() {}


    }
}
