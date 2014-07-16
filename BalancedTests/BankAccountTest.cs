using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Balanced;

namespace BalancedTests
{
    [TestClass]
    public class BankAccountTest : BaseTest
    {
        BankAccount ba;

        [TestInitialize()]
        public void SetUp()
        {
            Customer customer = createPersonCustomer();
            ba = createBankAccount();
            ba.AssociateToCustomer(customer);
        }

        [TestMethod]
        public void TestBankAccountCreate()
        {
            Assert.AreEqual("Johann Bernoulli", ba.name);
            Assert.AreEqual("121000358", ba.routing_number);
            Assert.IsTrue(ba.account_number.EndsWith("0002"));
            Assert.AreEqual("checking", ba.account_type);
        }

        [TestMethod]
        public void TestBankAccountAssociateToCustomer()
        {
            Customer customer = createPersonCustomer();
            ba = createBankAccount();
            ba.AssociateToCustomer(customer);

            Assert.AreEqual(customer.href, ba.customer.href);
        }
    }
}
