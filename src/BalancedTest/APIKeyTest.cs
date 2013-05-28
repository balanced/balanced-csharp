using Balanced;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BalancedTest
{
    [TestClass]
    public class APIKeyTest : Test
    {
        [TestMethod]
        public void TestCreateAnonymous()
        {
            Settings.configure(null);

            APIKey key = new APIKey();
            key.Meta["test"] = "this";
            key.Save();
            Assert.IsNotNull(key.Id);
            Assert.IsNotNull(key.Secret);
            var meta = new Dictionary<String, String>()
            {
                {"test", "this"}
            };
            CollectionAssert.AreEqual(key.Meta, meta);
        }

        [TestMethod]
        public void TestCreate()
        {
            Assert.IsNotNull(Settings.Secret);

            APIKey key = new APIKey();
            key.Save();
            Assert.IsNotNull(key.Id);
            Assert.IsNotNull(key.Secret);
        }

        [TestMethod]
        public void TestDelete()
        {
            Settings.configure(null);

            APIKey key = new APIKey();
            key.Save();
            Settings.configure(key.Secret);
            key = new APIKey();
            key.Save();
            Assert.AreEqual(2, APIKey.Query.Total);
            key.Delete();
            Assert.AreEqual(1, APIKey.Query.Total);
        }

        [TestMethod]
        public void TestAll()
        {
            Settings.configure(null);

            APIKey key1 = new APIKey();
            key1.Save();
            Settings.configure(key1.Secret);

            APIKey key2 = new APIKey();
            key2.Save();

            APIKey key3 = new APIKey();
            key3.Save();

            IList<APIKey> keys = APIKey.Query.All();
            var expectedKeyIds = keys.Select(v => v.Id).ToList();
            var keyIds = keys.Select(v => v.Id).ToList();
            CollectionAssert.AreEqual(expectedKeyIds, keyIds);
        }
    }
}
