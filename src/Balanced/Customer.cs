using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balanced
{
    public class Customer : Resource
    {
        public Dictionary<String, String> address { get; set; }
        public String bank_accounts_uri { get; set; }
        public String business_name { get; set; }
        public String cards_uri { get; set; }
        public String credits_uri { get; set; }
        public String debits_uri { get; set; }
        public String dob { get; set; }
        public String ein { get; set; }
        public String email { get; set; }
        public String facebook { get; set; }
        public String holds_uri { get; set; }
        public Boolean is_identity_verified { get; set; }
        public Dictionary<String, String> meta { get; set; }
        public String name { get; set; }
        public String phone { get; set; }
        public String refunds_uri { get; set; }
        public String ssn_last4 { get; set; }
        public String twitter { get; set; }

        public BankAccount.Collection BankAccounts { get; set; }
        public Card.Collection Cards { get; set; }
        public Hold.Collection Holds { get; set; }
        public Credit.Collection Credits { get; set; }
        public Debit.Collection Debits { get; set; }
        public Refund.Collection Refunds { get; set; }

        public Customer() : base() { }
        public Customer(string uri) : base(uri) { }
        public Customer(IDictionary<string, object> payload) : base(payload) { }

        public class Collection : ResourceCollection<Customer>
        {
            public Collection(String uri) : base(typeof(Customer), uri) { }
        };

        public static ResourceQuery<Customer> Query()
        {
            return new ResourceQuery<Customer>(typeof(Customer), string.Format("/v/%s/%s", Settings.Version, "customers"));
        }

        public static Customer Get(string uri)
        {
            return new Customer((new Client()).Get(uri));
        }

        public override void Save()
        {
            if (id == null && uri == null)
            {
                uri = String.Format("/v%s/%s", Settings.Version, "customers");
            }
            base.Save();
        }

        public override void Deserialize(IDictionary<string, object> data)
        {
            base.Deserialize(data);
            BankAccounts = new BankAccount.Collection(bank_accounts_uri);
            Cards = new Card.Collection(cards_uri);
            Holds = new Hold.Collection(holds_uri);
            Credits = new Credit.Collection(credits_uri);
            Debits = new Debit.Collection(debits_uri);
            Refunds = new Refund.Collection(refunds_uri);
        }

        public void AddBankAccount(string bankAccountUri)
        {
            IDictionary<string, object> payload = new Dictionary<string, object>();
            payload["bank_account_uri"] = bankAccountUri;
            IDictionary<string, object> response = Client.Put(uri, payload);
            Deserialize(response);
        }

        public void AddBankAccount(BankAccount bankAccount)
        {
            AddBankAccount(bankAccount.uri);
        }

        public BankAccount ActiveBankAccount()
        {
            return (BankAccounts.Query
                                .Filter("is_valid", true)
                                .OrderBy("created_at", ResourceQueryOrder.DESCENDING)
                                .First());
        }

        public void AddCard(string card_uri)
        {
            IDictionary<string, object> payload = new Dictionary<string, object>();
            payload["card_uri"] = card_uri;
            IDictionary<string, object> response = Client.Put(uri, payload);
            Deserialize(response);
        }

        public void AddCard(Card card)
        {
            AddCard(card.uri);
        }

        public Card ActiveCard()
        {
            return (Cards.Query
                          .Filter("is_valid", true)
                          .OrderBy("created_at", ResourceQueryOrder.DESCENDING)
                          .First());
        }

        public Credit Credit(
            int amount,
            string description,
            string destinationUri,
            string appearsOnStatementAs,
            string debitUri,
            IDictionary<string, string> meta)
        {
            return Credits.Create(amount, description, destinationUri, appearsOnStatementAs, debitUri, meta);
        }

        public Debit Debit(
            int amount,
            string description,
            string sourceUri,
            string appearsOnStatementAs,
            string onBehalfOfUri,
            IDictionary<string, string> meta)
        {
            return Debits.Create(amount, description, sourceUri, appearsOnStatementAs, onBehalfOfUri, meta);
        }
    }
}
