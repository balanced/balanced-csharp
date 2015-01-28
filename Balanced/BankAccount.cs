using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balanced
{
    public class BankAccount : FundingInstrument
    {
        [JsonIgnore]
        public static string resource_href
        {
            get { return "/bank_accounts"; }
        }

        // fields
        [ResourceField]
        public string account_type { get; set; }
        [ResourceField]
        public string account_number { get; set; }
        [ResourceField]
        public Dictionary<string, string> address { get; set; }
        [ResourceField]
        public string name { get; set; }
        [ResourceField]
        public string routing_number { get; set; }

        // attributes
        [ResourceField(field = "bank_accounts.bank_account_verification", link = true, serialize = false)]
        public BankAccountVerification verification { get; set; }

        [ResourceField(field = "bank_accounts.bank_account_verifications", link = true, serialize = false)]
        public BankAccountVerification.Collection verifications { get; set; }

        [ResourceField(field = "bank_accounts.credits", link = true, serialize = false)]
        public Credit.Collection credits { get; set; }

        [ResourceField(field = "bank_accounts.customer", link = true)]
        public Customer customer { get; set; }

        [ResourceField(field = "bank_accounts.debits", link = true, serialize = false)]
        public Debit.Collection debits { get; set; }


        public BankAccount() { }

        public BankAccount(Dictionary<string, object> payload) { }

        public static BankAccount Fetch(string href)
        {
            return Resource.Fetch<BankAccount>(href);
        }

        public static Task<BankAccount> FetchAsync(string href)
        {
            return Resource.FetchAsync<BankAccount>(href);
        }

        public void Save()
        {
            this.Save<BankAccount>();
        }

        public Task SaveAsync()
        {
            return this.SaveAsync<BankAccount>();
        }

        public void Reload()
        {
            this.Reload<BankAccount>();
        }

        public Task ReloadAsync()
        {
            return this.ReloadAsync<BankAccount>();
        }

        public void AssociateToCustomer(Customer customer)
        {
            this.AssociateToCustomer(customer.href);
        }

        public void AssociateToCustomer(string href)
        {
            AssociateToCustomerAsync(href).GetAwaiter().GetResult();
        }

        public Task AssociateToCustomerAsync(Customer customer)
        {
            return this.AssociateToCustomerAsync(customer.href);
        }

        public async Task AssociateToCustomerAsync(string href)
        {
            if (href != null)
            {
                links.Add("customer", href);
                await this.SaveAsync();
            }
        }

        public override Task<Credit> CreditAsync(Dictionary<string, object> payload)
        {
            return credits.CreateAsync(payload);
        }

        public override Task<Debit> DebitAsync(Dictionary<string, object> payload)
        {
            return debits.CreateAsync(payload);
        }

        public BankAccountVerification Verify()
        {
            return verifications.Create();
        }

        public Task<BankAccountVerification> VerifyAsync()
        {
            return verifications.CreateAsync();
        }

        public class Collection : ResourceCollection<BankAccount>
        {
            public Collection() : base(resource_href) { }
            public Collection(string href) : base(href) { }
        }

        public static ResourceQuery<BankAccount> Query()
        {
            return new ResourceQuery<BankAccount>(resource_href);
        }

        
    }
}
