using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Balanced;

namespace BalancedTests
{
    [TestClass]
    public class MarketplaceTest : BaseTest
    {
        [TestMethod]
        public void TestMarketplaceMine()
        {
            Marketplace mp = Balanced.Marketplace.Mine();
        }
    }
}
