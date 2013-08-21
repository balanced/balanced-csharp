using Balanced;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BalancedTest
{
    [TestClass]
    public class BankAccountVerificationTest : Test
    {
        protected BankAccount ba;
        protected BankAccountVerification bav;

        [TestInitialize]
        public new void Initialize()
        {
            base.Initialize();
            ba = CreateBankAccount(null);
            bav = ba.Verify();
        }

        [TestMethod]
        [ExpectedException(typeof(BankAccountVerificationFailure))]
        public void TestFailedConfirm()
        {
            bav.Confirm(12, 13);
        }
    
        [TestMethod]
        [ExpectedException(typeof(BankAccountVerificationFailure))]
        public void TestDoubleConfirm()
        {
            bav.Confirm(1, 1);
            bav.Confirm(1, 1);
        }
    
        [TestMethod]
        public void TestExhaustedConfirm()
        {
            while (bav.remaining_attempts != 1)
            {
                try
                {
                    bav.Confirm(12, 13);
                }
                catch (BankAccountVerificationFailure)
                {
                    bav.Refresh();
                    Assert.AreEqual(BankAccountVerification.pending, bav.state);
                }
            }
            try
            {
                bav.Confirm(12, 13);
            }
            catch (BankAccountVerificationFailure)
            {
                bav.Refresh();
                Assert.AreEqual(BankAccountVerification.failed, bav.state);
            }
            Assert.AreEqual(bav.remaining_attempts, 0);
            bav = ba.Verify();
            bav.Confirm(1, 1);
            Assert.AreEqual(BankAccountVerification.verified, bav.state);
        }

    }
}
