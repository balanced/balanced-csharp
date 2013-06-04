using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balanced
{
    public class Refund : Resource
    {
        public DateTime CreatedAt { get; set; }
        public Dictionary<String, String> Meta { get; set; }
        public int Amount { get; set; }
        public string Description { get; set; }
        public Account Account { get; set; }
        public string AppearsOnStatmentAs { get; set; }
        public string TransactionNumber { get; set; }
        public Debit Debit { get; set; }
        public string AccountUri { get; set; }

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
