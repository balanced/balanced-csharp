using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Balanced;
using System.Collections.Generic;

namespace BalancedTests
{
    [TestClass]
    public class DebitTest : BaseTest
    {
        [TestMethod]
        public void TestDebitCreate()
        {
            Customer customer = createPersonCustomer();
            Card card = createCard();
            card.AssociateToCustomer(customer);

            Dictionary<string, object> meta = new Dictionary<string, object>();
            meta.Add("invoice_id", "12141");

            Dictionary<string, object> payload = new Dictionary<string, object>();
            payload.Add("amount", 10000);
            payload.Add("description", "A simple debit");
            payload.Add("meta", meta);

            Debit debit = card.Debit(payload);
            Assert.IsNotNull(debit.href);
            Assert.AreEqual(10000, debit.amount);
            Assert.AreEqual("A simple debit", debit.description);
        }

        [TestMethod]
        public void TestDebitCreateNoCustomer()
        {
            Card card = createCard();

            Dictionary<string, object> meta = new Dictionary<string, object>();
            meta.Add("invoice_id", "12141");

            Dictionary<string, object> payload = new Dictionary<string, object>();
            payload.Add("amount", 10000);
            payload.Add("description", "A simple debit");
            payload.Add("meta", meta);

            Debit debit = card.Debit(payload);
            Assert.IsNotNull(debit.href);
            Assert.AreEqual(10000, debit.amount);
            Assert.AreEqual("A simple debit", debit.description);
        }

        [TestMethod]
        public void TestRefund()
        {
            Card card = createCard();

            Dictionary<string, object> meta = new Dictionary<string, object>();
            meta.Add("invoice_id", "12141");

            Dictionary<string, object> payload = new Dictionary<string, object>();
            payload.Add("amount", 10000);
            payload.Add("description", "A simple debit");
            payload.Add("meta", meta);

            Debit debit = card.Debit(payload);
            Assert.IsNotNull(debit.href);
            Assert.AreEqual(10000, debit.amount);
            Assert.AreEqual("A simple debit", debit.description);

            Refund refund = debit.Refund();

            Assert.AreEqual(debit.amount, refund.amount);
        }

        [TestMethod]
        public void TestDebitBankAccountVerified()
        {
            Customer customer = new Customer();
            customer.Save();

            BankAccount ba = createBankAccount();

            BankAccountVerification bankAccountVerification = ba.Verify();
            bankAccountVerification.Confirm(1, 1);
            bankAccountVerification.Reload();

            Dictionary<string, object> payload = new Dictionary<string, object>();
            payload.Add("amount", 100000);

            Debit debit = ba.Debit(payload);

            Assert.AreEqual("succeeded", debit.status);
            Assert.AreEqual(100000, debit.amount);
        }

        [TestMethod]
        public void TestDebitBankAccountUnverifiedNoCustomer()
        {
            Customer customer = new Customer();
            customer.Save();

            BankAccount ba = createBankAccount();
            BankAccountVerification verification = ba.Verify();
            verification.Confirm(1, 1);

            Dictionary<string, object> payload = new Dictionary<string, object>();
            payload.Add("amount", 100000);

            Debit debit = ba.Debit(payload);

            Assert.AreEqual("succeeded", debit.status);
            Assert.AreEqual(100000, debit.amount);
        }

        [TestMethod]
        public void TestDebitFilter()
        {
            Debit[] debits = new Debit[3];
            Dictionary<string, object> payload = new Dictionary<string, object>();
            payload.Add("amount", 100000);
            Dictionary<string, object> payload2 = new Dictionary<string, object>();
            payload2.Add("amount", 777);
            Dictionary<string, object> payload3 = new Dictionary<string, object>();
            payload3.Add("amount", 555);

            Card card = createCard();
            debits[0] = card.Debit(payload);
            debits[1] = card.Debit(payload2);
            debits[2] = card.Debit(payload3);

            ResourceQuery<Debit> query = card.debits.Query().Filter("amount", "=", 777);
            Assert.AreEqual(1, query.Total());
            Debit res = query.First();
            Assert.AreEqual(debits[1].id, res.id);

            query = card.debits.Query().Filter("amount", 777);
            Assert.AreEqual(1, query.Total());
            Assert.AreEqual(debits[1].id, query.First().id);

            query = (
                card
                .debits
                .Query()
                .Filter("amount", "<", 800)
                .OrderBy("created_at", ResourceQuery<Debit>.SortOrder.ASCENDING)
            );
            Assert.AreEqual(2, query.Total());

            List<Debit> allDebits = query.All();
            Assert.AreEqual(debits[1].id, allDebits[0].id);
            Assert.AreEqual(debits[2].id, allDebits[1].id);

            query = (
                    card
                    .debits
                    .Query()
                    .Filter("amount", ">", 600)
                    .Filter("amount", "<", 800)
                    .OrderBy("amount", ResourceQuery<Debit>.SortOrder.DESCENDING)
                );
            Assert.AreEqual(1, query.Total());

            allDebits = query.All();
            Assert.AreEqual(debits[1].id, allDebits[0].id);
        }
    }
}
