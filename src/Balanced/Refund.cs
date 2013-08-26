using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balanced
{
    public class Refund : Resource
    {
        public DateTime created_at { get; set; }
        public IDictionary<string, object> meta { get; set; }
        public int amount { get; set; }
        public string description { get; set; }
        public string appears_on_statement_as { get; set; }
        public string transaction_number { get; set; }
        public string account_uri { get; set; }
        public string customer_uri { get; set; }
        public string debit_uri { get; set; }

        public Account Account { get; set; }
        public Customer Customer { get; set; }
        public Debit Debit { get; set; }

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
                payload["amount"] = amount; 
                if (description != null) { payload["description"] = description; }
                if (meta != null) { payload["meta"] = meta; }
                return this.Create(payload);
            }
        }
        public override void Deserialize(IDictionary<string, object> data)
        {
            base.Deserialize(data);
            Account = new Account(account_uri);
            Customer = new Customer(customer_uri);
            Debit = new Debit(debit_uri);
        }
    }
}
