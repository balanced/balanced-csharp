using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Balanced;
using System.Collections.Generic;

namespace BalancedTests
{
    public class BaseTest
    {
        protected Marketplace mp;

        [TestInitialize()]
        public void setUp()
        {
            ApiKey key = new ApiKey();
            key.Save();
            Balanced.Balanced.configure(key.secret);
            Marketplace marketplace = new Marketplace();
            marketplace.Save();
            mp = marketplace;
        }

        protected Card createCard()
        {
            Dictionary<string, string> address = new Dictionary<string, string>();
            address.Add("line1", "123 Fake Street");
            address.Add("city", "Jollywood");
            address.Add("postal_code", "90210");

            Card card = new Card();
            card.name = "Homer Jay";
            card.number = "4112344112344113";
            card.cvv = "123";
            card.expiration_month = 12;
            card.expiration_year = 2016;
            card.address = address;
            card.Save();
            return card;
        }

        protected Card createCreditableCard()
        {
            Card card = new Card();
            card.name = "Johannes Bach";
            card.number = "4342561111111118";
            card.expiration_month = 05;
            card.expiration_year = 2016;
            card.Save();
            return card;
        }

        protected Card createNonCreditableCard()
        {
            Card card = new Card();
            card.name = "Georg Telemann";
            card.number = "4111111111111111";
            card.expiration_month = 12;
            card.expiration_year = 2016;
            card.Save();
            return card;
        }
        
        protected BankAccount createBankAccount()
        {
            BankAccount bankAccount = new BankAccount();
            bankAccount.name = "Johann Bernoulli";
            bankAccount.routing_number = "121000358";
            bankAccount.account_number = "9900000002";
            bankAccount.account_type = "checking";
            bankAccount.Save();
            return bankAccount;
        }
        
        protected Customer createPersonCustomer()
        {
            Dictionary<string, string> meta = new Dictionary<string, string>();
            meta.Add("meta can store", "any flat key/value data you like");
            meta.Add("github", "https://github.com/balanced");
            meta.Add("more_additional_data", "54.8");

            Dictionary<string, string> address = new Dictionary<string, string>();
            address.Add("city", "San Francisco");
            address.Add("state", "CA");
            address.Add("postal_code", "94103");
            address.Add("line1", "965 Mission St");
            address.Add("country_code", "US");

            Customer customer = new Customer();
            customer.name = "John Lee Hooker";
            customer.phone = "(904) 555-1796";
            customer.dob_month = 1;
            customer.dob_year = 1980;
            customer.meta = meta;
            customer.address = address;
            customer.ssn_last4 = "3209";
            customer.Save();

            return customer;
        }
        
        protected Customer createBusinessCustomer()
        {
            Dictionary<string, string> meta = new Dictionary<string, string>();
            meta.Add("meta can store", "any flat key/value data you like");
            meta.Add("github", "https://github.com/balanced");
            meta.Add("more_additional_data", "54.8");

            Dictionary<string, string> address = new Dictionary<string, string>();
            address.Add("city", "San Francisco");
            address.Add("state", "CA");
            address.Add("postal_code", "94103");
            address.Add("line1", "965 Mission St");
            address.Add("country_code", "US");

            Customer customer = new Customer();
            customer.business_name = "Balanced";
            customer.ein = "123456789";
            customer.name = "John Lee Hooker";
            customer.phone = "(904) 555-1796";
            customer.meta = meta;
            customer.address = address;
            customer.Save();

            return customer;
        }
    }
}
