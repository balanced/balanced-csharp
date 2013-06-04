using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balanced
{
    class Debit : Resource
    {
        public DateTime CreatedAt;
        public Dictionary<String, String> Meta;
        public int Amount;
        public String Description;
        public String TransactionNumber;
        public Card Card;
        public String CardUri;
        public String AccountUri;
        public Account Account;
        public String HoldUri;
        public Hold Hold;
        public String RefundsUri;
        public Refund.Collection Refunds;

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
            IDictionary<string, object> payload = new Dictionary<string, object>();
            if (amount != null) { payload["amount"] = amount; }
            if (description != null) { payload["description"] = description; }
            if (meta != null) { payload["meta"] = meta; }
            return Refunds.Create(payload);
        }

        public Refund Refund(int amount)
        {
            return Refund(amount, null, null);
        }

        public Refund Refund()
        {
            //todo
            //return Refund(null, null, null);
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
