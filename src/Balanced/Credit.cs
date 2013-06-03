using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balanced
{
    class Credit : Resource
    {
        public DateTime created_at;
        public int amount;
        public String description;
        public String status;
        public BankAccount bank_account;
        public String account_uri;
        public Account account;
        public Dictionary<String, String> meta;
        public class Collection : ResourceCollection<Credit>
        {
            public Collection(String uri) : base(typeof(Credit), uri) {}
        };

    }
}
