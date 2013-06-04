using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balanced
{
    class Hold : Resource
    {
        public DateTime CreatedAt;
        public Dictionary<String, String> Meta;
        public int Amount;
        public DateTime ExpiresAt;
        public String Description;
        public Debit Debit;
        public String TransactionNumber;
        public Boolean IsVoid;
        public String AccountUri;
        public Account Account;
        public String CardUri;
        public Card Card;
        public Hold() : base() { }
        public Hold(string uri) : base(uri) { }
        public Hold(IDictionary<string, object> payload) : base(payload) { }

        public class Collection : ResourceCollection<Hold>
        {
            public Collection(String uri) : base(typeof(Hold), uri) { }

            public Hold Create(int amount,
                         string description,
                         string sourceURI,
                         IDictionary<string, string> meta)
            {
                IDictionary<string, object> payload = new Dictionary<string, object>();
                payload["amount"] = amount;
                if (description != null) { payload["description"] = description; }
                if (sourceURI != null) { payload["source"] = sourceURI; }
                if (meta != null) { payload["meta"] = meta; }
                return this.Create(payload);
            }
        };

        public static Hold Get(String uri)
        {
            return new Hold((new Client()).Get(uri));
        }

        public Account GetAccount()
        {
            if (Account == null)
                Account = new Account();
            return Account;
        }

        public Card GetCard()
        {
            if (Card == null)
                Card = new Card();
            return Card;
        }

        public void Void_()
        {
            IsVoid = true;
            Save();
        }

        public Debit Capture(int amount)
        {
            IDictionary<string, object> payload = new Dictionary<string, object>();
            payload["hold_uri"] = Uri;
            payload["amount"] = Amount;
            Debit = Account.Debits.Create(payload);
            return Debit;
        }

        public Debit Capture()
        {
            IDictionary<string, object> payload = new Dictionary<string, object>();
            payload["hold_uri"] = Uri;
            Debit = Account.Debits.Create(payload);
            return Debit;
        }


    }
}
