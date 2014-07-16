using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Balanced;
using System.Collections.Generic;

namespace BalancedTests
{
    [TestClass]
    public class CallbackTest : BaseTest
    {
        [TestMethod]
        public void TestCallbackCreateDelete()
        {
            Callback.Collection callbacks = new Callback.Collection();
            int total = callbacks.Total();
            Assert.AreEqual(0, total);

            Callback callback = new Callback();
            callback.url = "http://www.example.com/cb";
            callback.method = "post";
            callback.Save();

            callbacks = new Callback.Collection();

            Assert.AreEqual(callbacks.Total(), 1);
            Assert.AreEqual("http://www.example.com/cb", callback.url);
            Assert.AreEqual("post", callback.method);

            callback.Unstore();

            callbacks = new Callback.Collection();

            Assert.AreEqual(0, callbacks.Total());
        }
    }
}
