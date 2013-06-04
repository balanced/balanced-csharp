using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balanced
{
    public class Debit : Resource
    {
        public DateTime CreatedAt { get; set; }
        public Dictionary<String, String> Meta { get; set; }
        public int Amount { get; set; }
        public String Description { get; set; }
        public String TransactionNumber { get; set; }
        public Card Card { get; set; }
        public String CardUri { get; set; }
        public String AccountUri { get; set; }
        public Account Account { get; set; }
        public String HoldUri { get; set; }
        public Hold Hold { get; set; }
        public String RefundsUri { get; set; }
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

        public Debit(IDictionary<string, object> payload) : base(payload) { }

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
                Account = new Account(AccountUri);
            return Account;
        }

        public Card GetCard()
        {
            if (Card == null)
                Card = new Card(CardUri);
            return Card;
        }

        public Hold GetHold()
        {
            if (Hold == null)
                Hold = new Hold(HoldUri);
            return Hold;
        }
    }
}
