using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Balanced;
using Balanced.Exceptions;
using System.Collections.Generic;

namespace BalancedTests
{
    [TestClass]
    public class CreditTest : BaseTest
    {
        [TestMethod]
        public void TestCreditCreate()
        {
            Card card = createCard();

            Dictionary<string, object> debitPayload = new Dictionary<string, object>();
            debitPayload.Add("amount", 1000);
            card.Debit(debitPayload);

            BankAccount ba = createBankAccount();

            Dictionary<string, object> creditPayload = new Dictionary<string, object>();
            creditPayload.Add("amount", 1000);
            creditPayload.Add("appears_on_statement_as", "Tasty Treats");

            Credit credit = ba.Credit(creditPayload);

            Assert.AreEqual(1000, credit.amount);
            Assert.AreEqual("Tasty Treats", credit.appears_on_statement_as);
        }

        [TestMethod]
        public void TestCreateCreditCard()
        {
            // prefund escrow
            Card fundingCard = createCard();
            Dictionary<string, object> debitPayload = new Dictionary<string, object>();
            debitPayload.Add("amount", 250000);
            fundingCard.Debit(debitPayload);

            // credit funds to Card
            Card card = createCreditableCard();
            Dictionary<string, object> creditPayload = new Dictionary<string, object>();
            creditPayload.Add("amount", 250000);
            Credit credit = card.Credit(creditPayload);

            Assert.AreEqual("succeeded", credit.status);
            Assert.AreEqual(250000, credit.amount);
        }

        [TestMethod]
        [ExpectedException(typeof(Balanced.Exceptions.FundingInstrumentNotCreditable))]
        public void TestCreateCreditCardCanCreditFalse()
        {
            // prefund escrow
            Card fundingCard = createCard();
            Dictionary<string, object> debitPayload = new Dictionary<string, object>();
            debitPayload.Add("amount", 250000);
            fundingCard.Debit(debitPayload);

            // attempt to credit funds to Card
            Card card = createNonCreditableCard();
            Dictionary<string, object> creditPayload = new Dictionary<string, object>();
            creditPayload.Add("amount", 250000);

            card.Credit(creditPayload);
        }

        [TestMethod]
        public void TestCreateCreditCardLimit()
        {
            // prefund escrow
            Card fundingCard = createCard();
            Dictionary<string, object> debitPayload = new Dictionary<string, object>();
            debitPayload.Add("amount", 250005);
            fundingCard.Debit(debitPayload);

            // attempt to credit funds to Card
            Card card = createCreditableCard();
            Dictionary<string, object> creditPayload = new Dictionary<string, object>();
            creditPayload.Add("amount", 250001);

            try
            {
                card.Credit(creditPayload);
            }
            catch (APIException e)
            {
                Assert.AreEqual(409, e.status_code);
                Assert.AreEqual("amount-exceeds-limit", e.category_code);
            }
        }

        [TestMethod]
        public void TestCreateCreditCardRequireName()
        {
            // prefund escrow
            Card fundingCard = createCard();
            Dictionary<string, object> debitPayload = new Dictionary<string, object>();
            debitPayload.Add("amount", 250000);
            fundingCard.Debit(debitPayload);

            // attempt to credit funds to Card
            Card card = new Card();
            card.number = "4342561111111118";
            card.expiration_month = 05;
            card.expiration_year = 2016;
            card.Save();

            Dictionary<string, object> creditPayload = new Dictionary<string, object>();
            creditPayload.Add("amount", 250000);

            try
            {
                card.Credit(creditPayload);
            }
            catch (APIException e)
            {
                Assert.AreEqual(400, e.status_code);
                Assert.AreEqual("name-required-to-credit", e.category_code);
            }
        }

        [TestMethod]
        public void TestReversal()
        {
            Card card = createCard();

            Dictionary<string, object> debitPayload = new Dictionary<string, object>();
            debitPayload.Add("amount", 1000);
            card.Debit(debitPayload);

            BankAccount ba = createBankAccount();

            Dictionary<string, object> creditPayload = new Dictionary<string, object>();
            creditPayload.Add("amount", 1000);
            creditPayload.Add("appears_on_statement_as", "Tasty Treats");

            Credit credit = ba.Credit(creditPayload);

            Reversal reversal = credit.Reverse();

            Assert.AreEqual(credit.amount, reversal.amount);
        }
    }
}
