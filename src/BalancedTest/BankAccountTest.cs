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
            BankAccount ba = new BankAccount();
            ba.name = "Homer Jay";
            ba.account_number = "112233a";
            ba.routing_number = "121042882";
            ba.type = BankAccount.checking;
            ba.Save();
        }
    }
}
