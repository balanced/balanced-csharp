using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balanced
{
    class Refund : Resource
    {
        public DateTime CreatedAt;
        public Dictionary<String, String> Meta;
        public int Amount;
        public string Description;
        public Account Account;
        public string AppearsOnStatmentAs;
        public string TransactionNumber;
        public Debit Debit;
        public string AccountUri;
        public class Collection : ResourceCollection<Refund>
        {
            public Collection(string uri) : base(typeof(Refund), uri) { }
        };
        public Refund() : base() { }
        public Refund(IDictionary<string, object> payload) : base(payload) { }


    }
}
