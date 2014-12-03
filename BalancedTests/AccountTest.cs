using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Balanced;
using Balanced.Exceptions;

namespace BalancedTests
{
    [TestClass]
    public class AccountTest : BaseTest
    {
        [TestMethod]
        public void TestAccountTransfer()
        {
            Customer merchant = createPersonCustomer();
            Account payable_account = merchant.Payable_Account();
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
            creditPayload.Add("order", order);

            Credit credit = payable_account.Credit(creditPayload);
            payable_account.Reload();

            Assert.AreEqual(payable_account.balance, 5000);
        }
    }
}
