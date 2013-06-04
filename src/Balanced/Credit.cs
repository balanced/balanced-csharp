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
