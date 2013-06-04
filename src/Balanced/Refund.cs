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

        public Refund() : base() { }

        public Refund(IDictionary<string, object> payload) : base(payload) { }

        public class Collection : ResourceCollection<Refund>
        {
            public Collection(string uri) : base(typeof(Refund), uri) { }

            public Refund Create(
                int amount,
                string description,
                IDictionary<string, string> meta)
            {
                IDictionary<string, object> payload = new Dictionary<string, object>();
                if (amount != null) { payload["amount"] = amount; }
                if (description != null) { payload["description"] = description; }
                if (meta != null) { payload["meta"] = meta; }
                return this.Create(payload);
            }
        }
    }
}
