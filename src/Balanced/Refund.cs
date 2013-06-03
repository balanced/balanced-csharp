using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balanced
{
    class Refund : Resource
    {
        public DateTime created_at;
        public Dictionary<String, String> meta;
        public int amount;
        public string description;
        public Account account;
        public string appears_on_statement_as;
        public string transaction_number;
        public Debit debit;
        public string account_uri;
        public class Collection : ResourceCollection<Refund>
        {
            public Collection(string uri) : base(uri) { }
        };

    }
}
