using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Balanced;
using Balanced.Exceptions;

namespace BalancedTests
{
    [TestClass]
    public class OrderTest : BaseTest
    {
        [TestMethod]
        public void TestOrderCreateWithVerifiedMerchant()
        {
            Customer merchant = createPersonCustomer();
            Assert.AreEqual("underwritten", merchant.merchant_status);

            Dictionary<string, object> payload = new Dictionary<string, object>();
            payload.Add("description", "Test order #452");
            Order order = merchant.createOrder(payload);

            Assert.IsNotNull(order.href);
            Assert.AreEqual(order.merchant.href, merchant.href);
        }

        [TestMethod]
        public void TestOrderDebitFromCreditTo()
        {
            Customer merchant = createPersonCustomer();
            BankAccount ba = createBankAccount();
            ba.AssociateToCustomer(merchant);
            Order order = merchant.createOrder(null);
            Card card = createCard();

            Dictionary<string, object> debitPayload = new Dictionary<string, object>();
            debitPayload.Add("description", "Debit for Order #234123");
            debitPayload.Add("amount", 5000);

            Debit debit = order.DebitFrom(card, debitPayload);
            order.Reload();

            Assert.AreEqual(debit.order.href, order.href);
            Assert.AreEqual(5000, debit.amount);
            Assert.AreEqual(5000, order.amount);
            Assert.AreEqual(5000, order.amount_escrowed);

            Dictionary<string, object> creditPayload = new Dictionary<string, object>();
            creditPayload.Add("description", "Payout for Order #234123");
            creditPayload.Add("amount", 5000);

            Credit credit = order.CreditTo(ba, creditPayload);
            order.Reload();

            Assert.AreEqual(credit.order.href, order.href);
            Assert.AreEqual(5000, debit.amount);
            Assert.AreEqual(5000, order.amount);
            Assert.AreEqual(0, order.amount_escrowed);
        }

        [TestMethod]
        public void TestOrderDebitCredit()
        {
            Customer merchant = createPersonCustomer();
            Order order = merchant.createOrder(null);
            Card card = createCard();
            BankAccount ba = createBankAccount();
            ba.AssociateToCustomer(merchant);

            Dictionary<string, object> debitPayload = new Dictionary<string, object>();
            debitPayload.Add("order", order.href);
            debitPayload.Add("description", "Debit for Order #234123");
            debitPayload.Add("amount", 5000);

            Debit debit = card.Debit(debitPayload);
            order.Reload();

            Assert.AreEqual(debit.order.href, order.href);
            Assert.AreEqual(5000, debit.amount);
            Assert.AreEqual(5000, order.amount);
            Assert.AreEqual(5000, order.amount_escrowed);

            Dictionary<string, object> creditPayload = new Dictionary<string, object>();
            creditPayload.Add("order", order.href);
            creditPayload.Add("description", "Payout for Order #234123");
            creditPayload.Add("amount", 5000);

            Credit credit = ba.Credit(creditPayload);
            order.Reload();

            Assert.AreEqual(credit.order.href, order.href);
            Assert.AreEqual(5000, credit.amount);
            Assert.AreEqual(5000, order.amount);
            Assert.AreEqual(0, order.amount_escrowed);
        }

        [TestMethod]
        public void TestOrderDebitBankAccountCredit()
        {
            Customer merchant = createPersonCustomer();
            Order order = merchant.createOrder(null);
            BankAccount ba = createBankAccount();
            ba.AssociateToCustomer(merchant);
            BankAccount buyerBA = createBankAccount();
            BankAccountVerification verification = buyerBA.Verify();
            verification.Confirm(1, 1);

            Dictionary<string, object> debitPayload = new Dictionary<string, object>();
            debitPayload.Add("order", order.href);
            debitPayload.Add("description", "Debit for Order #234123");
            debitPayload.Add("amount", 5000);

            Debit debit = buyerBA.Debit(debitPayload);
            order.Reload();

            Assert.AreEqual(debit.order.href, order.href);
            Assert.AreEqual(5000, debit.amount);
            Assert.AreEqual(5000, order.amount);
            Assert.AreEqual(5000, order.amount_escrowed);

            Dictionary<string, object> creditPayload = new Dictionary<string, object>();
            creditPayload.Add("order", order.href);
            creditPayload.Add("description", "Payout for Order #234123");
            creditPayload.Add("amount", 5000);

            Credit credit = ba.Credit(creditPayload);
            order.Reload();

            Assert.AreEqual(credit.order.href, order.href);
            Assert.AreEqual(5000, credit.amount);
            Assert.AreEqual(5000, order.amount);
            Assert.AreEqual(0, order.amount_escrowed);
        }

        [TestMethod]
        public void testOrderNoOverCredit()
        {
            Customer merchant = createPersonCustomer();
            Order order = merchant.createOrder(null);
            BankAccount ba = createBankAccount();
            ba.AssociateToCustomer(merchant);
            BankAccount buyerBA = createBankAccount();
            BankAccountVerification verification = buyerBA.Verify();
            verification.Confirm(1, 1);

            Dictionary<string, object> debitPayload = new Dictionary<string, object>();
            debitPayload.Add("order", order.href);
            debitPayload.Add("description", "Debit for Order #234123");
            debitPayload.Add("amount", 5000);

            Debit debit = buyerBA.Debit(debitPayload);
            order.Reload();

            Assert.AreEqual(debit.order.href, order.href);
            Assert.AreEqual(5000, debit.amount);
            Assert.AreEqual(5000, order.amount);
            Assert.AreEqual(5000, order.amount_escrowed);

            Dictionary<string, object> creditPayload = new Dictionary<string, object>();
            creditPayload.Add("order", order.href);
            creditPayload.Add("description", "Payout for Order #234123");
            creditPayload.Add("amount", 6000);

            Credit credit = null;

            try {
                credit = ba.Credit(creditPayload);
            }
            catch (APIException e) {
                Assert.AreEqual(409, e.status_code);
            }

            order.Reload();

            Assert.AreEqual(5000, order.amount);
            Assert.AreEqual(5000, order.amount_escrowed);
        }
    }
}
