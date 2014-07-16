using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Balanced;
using Balanced.Exceptions;

namespace BalancedTests
{
    [TestClass]
    public class BankAccountVerificationTest : BaseTest
    {
        [TestMethod]
        public void TestBankAccountVerify()
        {
            BankAccount ba = createBankAccount();
            BankAccountVerification bav = ba.Verify();
            ba.Reload();

            Assert.AreEqual(ba.verification.id, bav.id);
            bav.Confirm(1, 1);
            Assert.AreEqual(bav.attempts, 1);
            Assert.AreEqual(bav.attempts_remaining, 2);
            Assert.AreEqual(bav.deposit_status, "succeeded");
            Assert.AreEqual(bav.verification_status, "succeeded");
        }

        [TestMethod]
        [ExpectedException(typeof(Balanced.Exceptions.APIException))]
        public void TestFailedConfirm()
        {
            BankAccount ba = createBankAccount();
            ba.Verify();
            ba.Reload();
            BankAccountVerification bav = ba.verification;
            bav.Confirm(12, 13);
        }

        [TestMethod]
        [ExpectedException(typeof(Balanced.Exceptions.APIException))]
        public void TestDoubleConfirm()
        {
            BankAccount ba = createBankAccount();
            ba.Verify();
            ba.Reload();
            BankAccountVerification bav = ba.verification;
            bav.Confirm(1, 1);
            bav.Confirm(1, 1);
        }

        [TestMethod]
        public void TestExhaustedConfirm()
        {
            BankAccount ba = createBankAccount();
            ba.Verify();
            ba.Reload();
            BankAccountVerification bav = ba.verification;
            while (bav.attempts_remaining != 1)
            {
                try
                {
                    bav.Confirm(12, 13);
                }
                catch (APIException)
                {
                    bav = BankAccountVerification.Fetch(bav.href);
                    Assert.AreEqual("succeeded", bav.deposit_status);
                }
            }
            try
            {
                bav.Confirm(12, 13);
            }
            catch (APIException)
            {
                bav = BankAccountVerification.Fetch(bav.href);
                Assert.AreEqual(bav.verification_status, "failed");
            }
            Assert.AreEqual(bav.attempts_remaining, 0);
            bav = ba.Verify();
            bav.Confirm(1, 1);
            Assert.AreEqual("succeeded", bav.verification_status);
            Assert.AreEqual(ba.href, bav.bank_account.href);
        }
    }
}
