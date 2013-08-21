using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balanced
{
    public class Account : Resource
    {
        public const string BUYER_ROLE = "buyer";       
        public const string MERCHANT_ROLE = "merchant";

        public DateTime created_at { get; set; }
        public string name { get; set; }
        public string email_address { get; set; }
        public string[] roles { get; set; }
        public string bank_accounts_uri { get; set; }
        public string cards_uri { get; set; }
        public string credits_uri { get; set; }
        public string debits_uri { get; set; }
        public string holds_uri { get; set; }
        public Dictionary<String, String> meta { get; set; }

        public Debit.Collection Debits { get; set; }
        public Credit.Collection Credits { get; set; }
        public Hold.Collection Holds { get; set; }
        public Card.Collection Cards { get; set; }
        public BankAccount.Collection BankAccounts { get; set; }           
        
        public class Collection : ResourceCollection<Account>
        {
            public Collection(string uri) : base(uri) { }
        };

        public static Account Get(string uri) 
        { 
            return new Account((new Client()).Get(uri));         
        }                                                        

        public Account() : base() {}                                   

        public Account(IDictionary<string, Object> payload) : base(payload)  {}                                                                  

        public Account(string uri) : base(uri) {}

        public override void Deserialize(IDictionary<string, object> data)
        {
            base.Deserialize(data);
            Debits = new Debit.Collection(debits_uri);
            Credits = new Credit.Collection(credits_uri);
            Holds = new Hold.Collection(holds_uri);
            Cards = new Card.Collection(cards_uri);
            BankAccounts = new BankAccount.Collection(bank_accounts_uri);
        }

        public Credit Credit(int amount, 
                             string description,
                             string destination_uri,
                             string appears_on_statement_as,
                             IDictionary<string, string> meta)
        {
            return Credits.Create(amount, description, destination_uri, appears_on_statement_as, null, meta);
        }

        public Credit Credit(int amount) {
            return Credit(amount, null, null, null, null);
        }
        
        public Debit Debit(int amount, 
                           string description,
                           string source_uri,
                           string appears_on_statement_as,
                           IDictionary<string, string> meta)
        {
            return Debits.Create(amount, description, source_uri, appears_on_statement_as, null, meta);
        }

        public Debit Debit(int amount) {
            return Debit(amount, null, null, null, null);
        } 

        public Hold Hold(int amount, 
                         string description,
                         string source_uri,
                         IDictionary<string, string> meta)
        {
            return Holds.Create(amount, description, source_uri, meta);
        }

        public Hold hold(int amount) {
            return Hold(amount, null, null, null);
        }

        public void AssociateBankAccount(string bank_account_uri)
        {
            IDictionary<string, object> payload = new Dictionary<string, object>();
            payload["bank_account_uri"] = bank_account_uri;
            IDictionary<string, object> response = Client.Put(uri, payload);
            Deserialize(response);
        }

        public void PromoteToMerchant(IDictionary<string, object> merchant)
        {
            IDictionary<string, object> payload = new Dictionary<string, object>();
            payload["merchant"] = merchant;
            IDictionary<string, object> response = Client.Put(uri, payload);
            Deserialize(response);
        }

        public void PromoteToMerchant(string merchant_uri)
        {
            IDictionary<string, object> payload = new Dictionary<string, object>();
            payload["merchant_uri"] = merchant_uri;
            IDictionary<string, object> response = Client.Put(uri, payload);
            Deserialize(response);
        }

        public void AssociateCard(String card_uri)
        {
            IDictionary<string, object> payload = new Dictionary<string, object>();
            payload["card_uri"] = card_uri;
            IDictionary<string, object> response = Client.Put(uri, payload);
            Deserialize(response);  
        }



    }
}
