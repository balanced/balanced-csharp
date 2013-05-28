using Balanced;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BalancedTest
{
    [TestClass]
    public class BankAccountTest : Test
    {
        [TestMethod]
        public void TestCreate()
        {
            var ba = new BankAccount();
            ba.Name = "Homer Jay";
            ba.AccountNumber = "112233a";
            ba.RoutingNumber = "121042882";
            ba.Save();
        }
    }
}
