using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balanced
{
    public class Credit : Resource
    {
        public DateTime CreatedAt { get; set; }
        public int Amount { get; set; }
        public String Description { get; set; }
        public String Status { get; set; }
        public BankAccount BankAccount { get; set; }
        public String AccountUri { get; set; }
        public Account Account { get; set; }
        public Dictionary<String, String> Meta { get; set; }

        public class Collection : ResourceCollection<Credit>
        {
            public Collection(String uri) : base(typeof(Credit), uri) { }

            public Credit Create(
                int amount,
                string description,
                string destinationUri,
                string appearsOnStatementAs,
                string debitUri,
                IDictionary<string, string> meta)
            {
                IDictionary<string, object> payload = new Dictionary<string, object>();
                payload["amount"] = amount;
                if (description != null) { payload["description"] = description; }
                if (destinationUri != null) { payload["destination_uri"] = destinationUri; }
                if (appearsOnStatementAs != null) { payload["appears_on_statement_as"] = appearsOnStatementAs; }
                if (meta != null) { payload["meta"] = meta; }
                return this.Create(payload);
            }
        };

    }
}
