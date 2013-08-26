using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balanced
{
    public class Hold : Resource
    {
        public DateTime created_at { get; set; }
        public IDictionary<string, object> meta { get; set; }
        public int amount { get; set; }
        public DateTime expires_at { get; set; }
        public String description{ get; set; }
        public String transaction_number { get; set; }
        public Boolean is_void { get; set; }
        public String account_uri { get; set; }
        public String card_uri { get; set; }
        public String customer_uri { get; set; }
        public String debit_uri { get; set; }

        public Customer Customer { get; set; }
        public Account Account { get; set; }
        public Card Card { get; set; }
        public Debit Debit { get; set; }

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

        public override void Deserialize(IDictionary<string, object> data)
        {
            base.Deserialize(data);
            Customer = new Customer(customer_uri);
            Account = new Account(account_uri);
            Card = new Card(card_uri);
            Debit = new Debit(debit_uri);
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
            is_void = true;
            Save();
        }

        public Debit Capture(int amount)
        {
            IDictionary<string, object> payload = new Dictionary<string, object>();
            payload["hold_uri"] = uri;
            payload["amount"] = amount;
            Debit = Account.Debits.Create(payload);
            return Debit;
        }

        public Debit Capture()
        {
            IDictionary<string, object> payload = new Dictionary<string, object>();
            payload["hold_uri"] = uri;
            Debit = Account.Debits.Create(payload);
            return Debit;
        }
    }
}
