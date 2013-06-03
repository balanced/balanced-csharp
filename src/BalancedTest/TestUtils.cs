using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Balanced;

namespace BalancedTest
{
    [TestClass]
    public class TestUtils
    {
        [TestMethod]
        public void TestPythonCase()
        {
            /*
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Users\test\log.txt", true))
            {
                file.Write(Utilities.ConvertToPythonCase("FooBarABC") + "\r\n");
            }*/
            Assert.AreEqual("a_string_here", Utilities.ConvertToPythonCase("aStringHere"));
            Assert.AreEqual("another_string", Utilities.ConvertToPythonCase("anotherString"));
            Assert.AreEqual("another_string_with_all_caps", Utilities.ConvertToPythonCase("anotherStringWithALLCaps"));
        }
    }
}
