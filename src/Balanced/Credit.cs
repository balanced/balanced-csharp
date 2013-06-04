using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balanced
{
    class Credit : Resource
    {
        public DateTime CreatedAt;
        public int Amount;
        public String Description;
        public String Status;
        public BankAccount BankAccount;
        public String AccountUri;
        public Account Account;
        public Dictionary<String, String> Meta;
        public class Collection : ResourceCollection<Credit>
        {
            public Collection(String uri) : base(typeof(Credit), uri) {}
        };

    }
}
