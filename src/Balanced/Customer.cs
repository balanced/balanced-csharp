using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balanced
{
    public class Customer : Resource
    {
        protected Client Client = new Client();
        public Dictionary<String, String> Address { get; set; }
        public String BankAccountsUri { get; set; }
        public BankAccount.Collection BankAccounts { get; set; }
        public String BusinessName { get; set; }
        public String CardsUri { get; set; }
        public Card.Collection Cards { get; set; }
        public String CreditsUri { get; set; }
        public Credit.Collection Credits { get; set; }
        public String DebitsUri { get; set; }
        public Debit.Collection Debits { get; set; }
        public String Dob { get; set; }
        public String Ein { get; set; }
        public String Email { get; set; }
        public String Facebook { get; set; }
        public String HoldsUri { get; set; }
        public Hold.Collection Holds { get; set; }
        public Boolean IsIdentityVerified { get; set; }
        public Dictionary<String, String> Meta { get; set; }
        public String Name { get; set; }
        public String Phone { get; set; }
        public String RefundsUri { get; set; }
        public Refund.Collection Refunds { get; set; }
        public String SsnLast4 { get; set; }
        public String Twitter { get; set; }

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
            if (Id == null && Uri == null)
            {
                Uri = String.Format("/v%s/%s", Settings.Version, "customers");
            }
            base.Save();
        }

        public void AddBankAccount(string bankAccountUri)
        {
            IDictionary<string, object> payload = new Dictionary<string, object>();
            payload["bank_account_uri"] = bankAccountUri;
            IDictionary<string, object> response = Client.Put(Uri, payload);
            Deserialize(response);
        }

        public void AddBankAccount(BankAccount bankAccount)
        {
            AddBankAccount(bankAccount.Uri);
        }

        public BankAccount ActiveBankAccount()
        {
            return (BankAccounts.Query
                                .Filter("is_valid", true)
                                .OrderBy("created_at", ResourceQueryOrder.DESCENDING)
                                .First());
        }

        public void AddCard(string cardUri)
        {
            IDictionary<string, object> payload = new Dictionary<string, object>();
            payload["card_uri"] = cardUri;
            IDictionary<string, object> response = Client.Put(Uri, payload);
            Deserialize(response);
        }

        public void AddCard(Card card)
        {
            AddCard(card.Uri);
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
