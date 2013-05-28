using Balanced;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;


namespace BalancedTest
{
    [TestClass]
    public class MarketplaceTest : Test
    {
        [TestMethod]
        public void TestCreate()
        {
            Settings.configure(null);

            var key = new APIKey();
            key.Save();
            Settings.configure(key.Secret);

            var mp = new Marketplace();
            Assert.IsNull(mp.Id);
            mp.Save();

            Assert.IsNotNull(mp.Id);
        }

        [TestMethod]
        [ExpectedException(typeof(Error))]
        public void TestDoubleCreate()
        {
            var mp = new Marketplace();
            mp.Save();
        }

        [TestMethod]
        public void TestMine()
        {
            Settings.configure(null);

            var key = new APIKey();
            key.Save();
            Settings.configure(key.Secret);

            var mp = new Marketplace();
            Assert.IsNull(mp.Id);
            mp.Save();

            Assert.AreEqual(mp.Id, Marketplace.Mine.Id);
        }

        [TestMethod]
        [ExpectedException(typeof(NoResultsFound))]
        public void TestNoMine()
        {
            Settings.configure(null);

            var key = new APIKey();
            key.Save();
            Settings.configure(key.Secret);

            var mp = Marketplace.Mine;
        }

        [TestMethod]
        public void TestTokenizeBankAccount()
        {
            var ba = Mine.TokenizeBankAccount(
                "Homer Jay",
                "112233a",
                "121042882"
                );
            Assert.AreEqual(ba.Name, "Homer Jay");
            Assert.AreEqual(ba.AccountNumber, "xxx233a");
            Assert.AreEqual(ba.RoutingNumber, "121042882");
        }
    }
}
