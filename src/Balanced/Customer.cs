using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balanced
{
    class Customer : Resource
    {
        public Dictionary<String, String> address;
        public String bank_accounts_uri;
        public BankAccount.Collection bank_accounts;
        public String business_name;
        public String cards_uri;
        public Card.Collection cards;
        public String credits_uri;
        public Credit.Collection credits;
        public String debits_uri;
        public Debit.Collection debits;
        public String dob;
        public String ein;
        public String email;
        public String facebook;
        public String holds_uri;
        public Hold.Collection holds;
        public Boolean is_identity_verified;
        public Dictionary<String, String> meta;
        public String name;
        public String phone;
        public String refunds_uri;
        public Refund.Collection refunds;
        public String ssn_last4;
        public String twitter;
        public class Collection : ResourceCollection<Customer>
        {
            public Collection(String uri) : base(uri) { }
        };            

    }
}
