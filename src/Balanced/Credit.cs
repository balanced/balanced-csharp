using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balanced
{
    public class Credit : Resource
    {
        public DateTime created_at { get; set; }
        public int amount { get; set; }
        public String description { get; set; }
        public String status { get; set; }
        public BankAccount bank_account { get; set; }
        public String account_uri { get; set; }
        public String customer_uri { get; set; }
        public Dictionary<String, String> meta { get; set; }

        public Account Account { get; set; }
        public Customer Customer { get; set; }

        public override void Deserialize(IDictionary<string, object> data)
        {
            base.Deserialize(data);
            Account = new Account(account_uri);
            Customer = new Customer(customer_uri);
        }

        public class Collection : ResourceCollection<Credit>
        {
            public Collection(String uri) : base(typeof(Credit), uri) { }

            public Credit Create(
                int amount,
                string description,
                string destination_uri,
                string appears_on_statement_as,
                string debit_uri,
                IDictionary<string, string> meta)
            {
                IDictionary<string, object> payload = new Dictionary<string, object>();
                payload["amount"] = amount;
                if (description != null) { payload["description"] = description; }
                if (destination_uri != null) { payload["destination_uri"] = destination_uri; }
                if (appears_on_statement_as != null) { payload["appears_on_statement_as"] = appears_on_statement_as; }
                if (meta != null) { payload["meta"] = meta; }
                return this.Create(payload);
            }
        };

    }
}
