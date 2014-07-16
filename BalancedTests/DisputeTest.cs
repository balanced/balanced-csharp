using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Balanced;
using System.Threading;

namespace BalancedTests
{
    [TestClass]
    public class DisputeTest : BaseTest
    {
        [TestMethod]
        public void TestDispute()
        {
            Customer customer = createPersonCustomer();

            Card card = new Card();
            card.number = "6500000000000002";
            card.cvv = "123";
            card.expiration_month = 12;
            card.expiration_year = 3000;
            card.Save();

            card.AssociateToCustomer(customer);

            Dictionary<string, object> payload = new Dictionary<string, object>();
            payload.Add("amount", 100000);
            payload.Add("description", "Donuts");

            String debit_href = card.Debit(payload).href;
            Dispute dispute = null;

            for (int i = 0; i <= 100; i++)
            {
                Debit debit = Balanced.Debit.Fetch(debit_href);
                if (debit.dispute != null)
                {
                    dispute = debit.dispute;
                    break;
                }
                Console.WriteLine("polling disputes...");
                Thread.Sleep(10000);
            }

            Assert.IsNotNull(dispute);
            Assert.AreEqual(100000, dispute.amount);
            Assert.AreEqual("fraud", dispute.reason);
            Assert.AreEqual("pending", dispute.status);
        }
    }
}
