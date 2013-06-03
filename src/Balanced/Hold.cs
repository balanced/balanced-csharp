using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balanced
{
    class Hold : Resource
    {
        public DateTime created_at;
        public Dictionary<String, String> meta;
        public int amount;
        public DateTime expires_at;
        public String description;
        public Debit debit;
        public String transaction_number;
        public Boolean is_void;
        public String account_uri;
        public Account account;
        public String card_uri;
        public Card card;
        public class Collection : ResourceCollection<Hold>
        {
            public Collection(String uri) : base(uri) { }
        };

    }
}
