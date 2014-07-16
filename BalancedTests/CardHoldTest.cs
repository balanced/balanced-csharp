using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Balanced;
using System.Collections.Generic;

namespace BalancedTests
{
    [TestClass]
    public class CardHoldTest : BaseTest
    {
        [TestMethod]
        public void TestCardHoldCreate()
        {
            Card card = createCard();

            Dictionary<string, object> payload = new Dictionary<string, object>();
            payload.Add("amount", 2000);

            CardHold cardHold = card.Hold(payload);
            cardHold.Save();

            Assert.AreEqual(2000, cardHold.amount);
        }

        [TestMethod]
        public void TestCardHoldCapturePartial()
        {
            Card card = createCard();

            Dictionary<string, object> payload = new Dictionary<string, object>();
            payload.Add("amount", 2000);

            CardHold cardHold = card.Hold(payload);

            Dictionary<string, object> capturePayload = new Dictionary<string, object>();
            capturePayload.Add("amount", 1000);

            Debit debit = cardHold.Capture(capturePayload);
            Assert.AreEqual(2000, cardHold.amount);
            Assert.AreEqual(1000, debit.amount);
            Assert.AreEqual(card.href, debit.source.href);
            Assert.IsInstanceOfType(debit.source, typeof(Card));
        }

        [TestMethod]
        public void TestCardHoldCapture()
        {
            Card card = createCard();

            Dictionary<string, object> payload = new Dictionary<string, object>();
            payload.Add("amount", 2000);

            CardHold cardHold = card.Hold(payload);

            Debit debit = cardHold.Capture();
            Assert.AreEqual(2000, debit.amount);
            Assert.AreEqual(card.href, debit.source.href);
        }

        [TestMethod]
        public void TestCardHoldVoid()
        {
            Card card = createCard();

            Dictionary<string, object> payload = new Dictionary<string, object>();
            payload.Add("amount", 2000);

            CardHold cardHold = card.Hold(payload);

            Assert.IsNull(cardHold.voided_at);

            cardHold.Unstore();
            cardHold.Reload();

            Assert.IsNotNull(cardHold.voided_at);
        }
    }
}
