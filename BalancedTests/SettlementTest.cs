using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Balanced;
using Balanced.Exceptions;

namespace BalancedTests
{
    [TestClass]
    public class SettlementTest : BaseTest
    {
        [TestMethod]
        public void TestSettlement()
        {
            Customer merchant = createPersonCustomer();
            Account payableAccount = merchant.PayableAccount();
            BankAccount ba = createBankAccount();
            ba.AssociateToCustomer(merchant);
            Order order = merchant.CreateOrder(null);
            Card card = createCard();

            Dictionary<string, object> debitPayload = new Dictionary<string, object>();
            debitPayload.Add("description", "Debit for Order #234123");
            debitPayload.Add("amount", 5000);

            Debit debit = order.DebitFrom(card, debitPayload);

            Dictionary<string, object> creditPayload = new Dictionary<string, object>();
            creditPayload.Add("description", "Payout for Order #234123");
            creditPayload.Add("amount", 5000);
            creditPayload.Add("order", order.href);

            Credit credit = payableAccount.Credit(creditPayload);
            payableAccount.Reload();

            Assert.AreEqual(payableAccount.balance, 5000);

            Dictionary<string, object> settlementPayload = new Dictionary<string, object>();
            settlementPayload.Add("description", "Payout for Order #234123");
            settlementPayload.Add("funding_instrument", ba.href);

            Settlement settlement = payableAccount.Settle(settlementPayload);
            payableAccount.Reload();
            Assert.AreEqual(0, payableAccount.balance);
            Assert.AreEqual(5000, settlement.amount);
        }

        [TestMethod]
        public void TestReverseSettlement()
        {
            Customer merchant = createPersonCustomer();
            Account payableAccount = merchant.PayableAccount();
            BankAccount ba = createBankAccount();
            ba.AssociateToCustomer(merchant);
            Order order = merchant.CreateOrder(null);
            Card card = createCard();

            Dictionary<string, object> debitPayload = new Dictionary<string, object>();
            debitPayload.Add("description", "Debit for Order #234123");
            debitPayload.Add("amount", 5000);

            Debit debit = order.DebitFrom(card, debitPayload);
            order.Reload();

            Dictionary<string, object> creditPayload = new Dictionary<string, object>();
            creditPayload.Add("description", "Payout for Order #234123");
            creditPayload.Add("amount", 5000);
            creditPayload.Add("order", order.href);

            Credit credit = payableAccount.Credit(creditPayload);
            payableAccount.Reload();

            Dictionary<string, object> settlementPayload = new Dictionary<string, object>();
            settlementPayload.Add("description", "Payout for Order #234123");
            settlementPayload.Add("funding_instrument", ba.href);

            Settlement settlement = payableAccount.Settle(settlementPayload);

            Order orderTwo = merchant.CreateOrder(null);
            Dictionary<string, object> debitTwoPayload = new Dictionary<string, object>();
            debitTwoPayload.Add("description", "Debit for Order #234123");
            debitTwoPayload.Add("amount", 5000);
            Debit debitTwo = order.DebitFrom(card, debitTwoPayload);

            Dictionary<string, object> creditTwoPayload = new Dictionary<string, object>();
            creditTwoPayload.Add("description", "Payout for Order #234123");
            creditTwoPayload.Add("amount", 5000);
            creditTwoPayload.Add("order", order.href);

            Credit creditTwo = payableAccount.Credit(creditTwoPayload);
            Reversal reversal = credit.Reverse();

            payableAccount.Settle(settlementPayload);

            payableAccount.Reload();
            Assert.AreEqual(0, payableAccount.balance);
        }

        [TestMethod]
        public void TestReverseSettlementWithNegativeBalance()
        {
            Customer merchant = createPersonCustomer();
            Account payableAccount = merchant.PayableAccount();
            BankAccount ba = createBankAccount();
            ba.AssociateToCustomer(merchant);
            Order order = merchant.CreateOrder(null);
            Card card = createCard();

            Dictionary<string, object> debitPayload = new Dictionary<string, object>();
            debitPayload.Add("description", "Debit for Order #234123");
            debitPayload.Add("amount", 5000);

            Debit debit = order.DebitFrom(card, debitPayload);
            order.Reload();

            Dictionary<string, object> creditPayload = new Dictionary<string, object>();
            creditPayload.Add("description", "Payout for Order #234123");
            creditPayload.Add("amount", 5000);
            creditPayload.Add("order", order.href);

            Credit credit = payableAccount.Credit(creditPayload);
            payableAccount.Reload();

            Dictionary<string, object> settlementPayload = new Dictionary<string, object>();
            settlementPayload.Add("description", "Payout for Order #234123");
            settlementPayload.Add("funding_instrument", ba.href);

            Settlement settlement = payableAccount.Settle(settlementPayload);

            Reversal reversal = credit.Reverse();
            payableAccount.Reload();
            Assert.AreEqual(payableAccount.balance, -5000);

            Dictionary<string, object> settlementTwoPayload = new Dictionary<string, object>();
            settlementTwoPayload.Add("description", "Payout for Order #234123");
            settlementTwoPayload.Add("funding_instrument", ba.href);

            Settlement settlementTwo = payableAccount.Settle(settlementTwoPayload);
            Assert.AreEqual(payableAccount.balance, -5000);
        }
    }
}