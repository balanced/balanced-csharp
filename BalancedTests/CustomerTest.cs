using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

using Balanced;
using Balanced.Exceptions;

namespace BalancedTests
{
    [TestClass]
    public class CustomerTest : BaseTest
    {
        [TestMethod]
        public void TestCreatePersonCustomer()
        {
            Customer customer = createPersonCustomer();

            Assert.AreEqual("any flat key/value data you like", customer.meta["meta can store"]);
            Assert.AreEqual("https://github.com/balanced", customer.meta["github"]);
            Assert.AreEqual("54.8", customer.meta["more_additional_data"]);
            Assert.AreEqual("San Francisco", customer.address["city"]);
            Assert.AreEqual("CA", customer.address["state"]);
            Assert.AreEqual("94103", customer.address["postal_code"]);
            Assert.AreEqual("965 Mission St", customer.address["line1"]);
            Assert.AreEqual("US", customer.address["country_code"]);
            Assert.AreEqual("John Lee Hooker", customer.name);
            Assert.AreEqual("(904) 555-1796", customer.phone);
            Assert.AreEqual(1, customer.dob_month);
            Assert.AreEqual(1980, customer.dob_year);
            Assert.AreEqual("xxxx", customer.ssn_last4);
        }

        [TestMethod]
        public void TestCreateBusinessCustomer()
        {
            Customer customer = createBusinessCustomer();

            Assert.AreEqual("any flat key/value data you like", customer.meta["meta can store"]);
            Assert.AreEqual("https://github.com/balanced", customer.meta["github"]);
            Assert.AreEqual("54.8", customer.meta["more_additional_data"]);
            Assert.AreEqual("San Francisco", customer.address["city"]);
            Assert.AreEqual("CA", customer.address["state"]);
            Assert.AreEqual("94103", customer.address["postal_code"]);
            Assert.AreEqual("965 Mission St", customer.address["line1"]);
            Assert.AreEqual("US", customer.address["country_code"]);
            Assert.AreEqual("Balanced", customer.business_name);
            Assert.AreEqual("123456789", customer.ein);
            Assert.AreEqual("John Lee Hooker", customer.name);
            Assert.AreEqual("(904) 555-1796", customer.phone);
        }


        [TestMethod]
        public void TestUpdateCustomer()
        {
            Customer customer = new Customer() { name = "Mike Jones" };
            customer.Save();

            customer.name = "Mike Richard Jones";
            customer.Save();

            Assert.AreEqual("Mike Richard Jones", customer.name);
        }

        [TestMethod]
        public void TestMerchantStatusNoMatch()
        {
            Dictionary<string, string> address = new Dictionary<string, string>();
            address.Add("city", "San Francisco");
            address.Add("state", "CA");
            address.Add("postal_code", "94103");
            address.Add("line1", "965 Mission St");
            address.Add("country_code", "US");

            Customer merchant = new Customer();
            merchant.name = "John Lee Hooker";
            merchant.phone = "(904) 555-1796";
            merchant.address = address;
            merchant.ssn_last4 = "3209";
            merchant.Save();

            Assert.AreEqual("no-match", merchant.merchant_status);
        }

        [TestMethod]
        public void TestMerchantStatusUnderwritten()
        {
            Customer merchant = createPersonCustomer();
            Assert.AreEqual("underwritten", merchant.merchant_status);
        }

        [TestMethod]
        public void TestBankAccounts()
        {
            Customer customer = createPersonCustomer();
            BankAccount ba = createBankAccount();
            Assert.IsNotNull(ba);
            Assert.IsNotNull(ba.href);
            ba.AssociateToCustomer(customer);
            BankAccount baFromCollection = (BankAccount)customer.bank_accounts.GetEnumerator().Current;
            Assert.AreEqual(ba.href, baFromCollection.href);
        }

        [TestMethod]
        public void TestCards()
        {
            Customer customer = createPersonCustomer();
            Card card = createCard();
            Assert.IsNotNull(card);
            Assert.IsNotNull(card.href);
            card.AssociateToCustomer(customer);
            Card cardFromCollection = (Card)customer.cards.GetEnumerator().Current;
            Assert.AreEqual(card.href, cardFromCollection.href);
        }

        [TestMethod]
        public void TestUnstore()
        {
            Customer buyer = createBusinessCustomer();
            buyer.Unstore();
        }

        [TestMethod]
        [ExpectedException(typeof(Balanced.Exceptions.APIException))]
        public void TestUnstoreAlreadyUnstored()
        {
            Customer buyer = createPersonCustomer();
            string href = buyer.href;
            buyer.Unstore();
            buyer = Balanced.Customer.Fetch(href);
        }

        /*[TestMethod]
        public void TestCustomerCollection()
        {
            int count = 0;
            Customer.Collection customers = new Customer.Collection();

            foreach (Customer c in customers)
            {
                var foo = c.name;
                count += 1;
            }

            Assert.AreEqual(customers.Total(), count);
        }*/
    }
}
