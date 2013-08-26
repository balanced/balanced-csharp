using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balanced
{
    public class Debit : Resource
    {
        public DateTime created_at { get; set; }
        public IDictionary<string, object> meta { get; set; }
        public int amount { get; set; }
        public String description { get; set; }
        public String transaction_number { get; set; }
        public String card_uri { get; set; }
        public String account_uri { get; set; }
        public String hold_uri { get; set; }
        public String refunds_uri { get; set; }
        public String customer_uri { get; set; }

        public Hold Hold { get; set; }
        public Account Account { get; set; }
        public Customer Customer { get; set; }
        public Card Card { get; set; }
        public Refund.Collection Refunds { get; set; }

        public class Collection : ResourceCollection<Debit>
        {
            public Collection(String uri) : base(typeof(Debit), uri) { }

            public Debit Create(
                int amount,
                string description,
                string sourceUri,
                string appearsOnStatementAs,
                string onBehalfOfUri,
                IDictionary<string, string> meta)
            {
                IDictionary<string, object> payload = new Dictionary<string, object>();
                payload["amount"] = amount;
                if (description != null) { payload["description"] = description; }
                if (sourceUri != null) { payload["source_uri"] = sourceUri; }
                if (appearsOnStatementAs != null) { payload["appears_on_statement_as"] = appearsOnStatementAs; }
                if (onBehalfOfUri != null) { payload["on_behalf_of_uri"] = onBehalfOfUri; }
                if (meta != null) { payload["meta"] = meta; }
                return this.Create(payload);
            }
        };

        public Debit() : base() {}

        public Debit(String uri) : base(uri) { }

        public Debit(IDictionary<string, object> payload) : base(payload) { }

        public override void Deserialize(IDictionary<string, object> data)
        {
            base.Deserialize(data);
            Hold = new Hold(hold_uri);
            Account = new Account(account_uri);
            Customer = new Customer(customer_uri);
            Card = new Card(card_uri);
            Refunds = new Refund.Collection(refunds_uri);
        }

        public Refund Refund(
            int amount,
            string description,
            IDictionary<string, string> meta)
        {
            return Refunds.Create(amount, description, meta);
        }

        public Refund Refund(int amount)
        {
            return Refund(amount, null, null);
        }

        public Refund Refund()
        {
            return new Refund();
        }

        public Account GetAccount()
        {
            if (Account == null)
                Account = new Account(account_uri);
            return Account;
        }

        public Card GetCard()
        {
            if (Card == null)
                Card = new Card(card_uri);
            return Card;
        }

        public Hold GetHold()
        {
            if (Hold == null)
                Hold = new Hold(hold_uri);
            return Hold;
        }
    }
}
