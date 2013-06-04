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

        public DateTime CreatedAt { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public string[] Roles { get; set; }
        public string BankAccountsUri { get; set; }
        public BankAccount.Collection BankAccounts { get; set; }
        public string CardsUri { get; set; }
        public Card.Collection Cards { get; set; }
        public string CreditsUri { get; set; }
        public Credit.Collection Credits { get; set; }
        public string DebitsUri { get; set; }
        public Debit.Collection Debits;                        
        public string HoldsUri;                               
        public Hold.Collection Holds;
        public Dictionary<String, String> Meta;                       
        
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

        public Credit Credit(int amount, 
                             string description,
                             string destinationUri,
                             string appearsOnStatementAs,
                             IDictionary<string, string> meta)
        {
            return Credits.Create(amount, description, destinationUri, appearsOnStatementAs, null, meta);
        }

        public Credit Credit(int amount) {
            return Credit(amount, null, null, null, null);
        }
        
        public Debit Debit(int amount, 
                           string description,
                           string sourceUri,
                           string appearsOnStatementAs,
                           IDictionary<string, string> meta)
        {
            return Debits.Create(amount, description, sourceUri, appearsOnStatementAs, null, meta);
        }

        public Debit Debit(int amount) {
            return Debit(amount, null, null, null, null);
        } 

        public Hold Hold(int amount, 
                         string description,
                         string sourceUri,
                         IDictionary<string, string> meta)
        {
            return Holds.Create(amount, description, sourceUri, meta);
        }

        public Hold hold(int amount) {
            return Hold(amount, null, null, null);
        }

        public void AssociateBankAccount(string bankAccountUri)
        {
            IDictionary<string, object> payload = new Dictionary<string, object>();
            payload["bank_account_uri"] = bankAccountUri;
            IDictionary<string, object> response = Client.Put(Uri, payload);
            Deserialize(response);
        }

        public void PromoteToMerchant(IDictionary<string, object> merchantMap)
        {
            IDictionary<string, object> payload = new Dictionary<string, object>();
            payload["merchant"] = merchantMap;
        }

        public void PromoteToMerchant(string merchantUri)
        {
            IDictionary<string, object> payload = new Dictionary<string, object>();
            payload["merchant_uri"] = merchantUri;
            IDictionary<string, object> response = Client.Put(Uri, payload);
            Deserialize(response);
        }

        public void AssociateCard(String cardUri)
        {
            IDictionary<string, object> payload = new Dictionary<string, object>();
            payload["card_uri"] = cardUri;
            IDictionary<string, object> response = Client.Put(Uri, payload);
            Deserialize(response);  
        }



    }
}
