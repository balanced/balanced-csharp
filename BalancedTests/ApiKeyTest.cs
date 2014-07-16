using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Balanced;
using System.Collections.Generic;

namespace BalancedTests
{
    [TestClass]
    public class ApiKeyTest
    {
        [TestMethod]
        public void TestApiKeyCreate()
        {
            ApiKey key = new ApiKey();
            key.Save();
            Assert.IsNotNull(key.secret);
        }
    
        [TestMethod]
        public void TestApiKeyDelete()
        {
            ApiKey key = new ApiKey();
            key.Save();
            Balanced.Balanced.configure(key.secret);
            key.Unstore();
        }

        [TestMethod]
        public void TestApiKeyCollection()
        {
            ApiKey key = new ApiKey();
            key.Save();
            Balanced.Balanced.configure(key.secret);
            ApiKey.Collection apiKeys = new ApiKey.Collection();
            Assert.AreEqual(1, apiKeys.Total());
        }

        [TestMethod]
        public void TestApiKeyQueryAll()
        {
            ApiKey key = new ApiKey();
            key.Save();
            Balanced.Balanced.configure(key.secret);
            Marketplace marketplace = new Marketplace();
            marketplace.Save();

            ApiKey key1 = new ApiKey();
            key1.SaveToMarketplace();
        
            ApiKey key2 = new ApiKey();
            key2.SaveToMarketplace();
        
            ApiKey key3 = new ApiKey();
            key3.SaveToMarketplace();
        
            List<ApiKey> keys = ApiKey.Query().All();
            Assert.AreEqual(4, keys.Count);
            List<String> key_guids = new List<String>();
            foreach (ApiKey k in keys) {
                key_guids.Add(k.id);
            }
            Assert.IsTrue(key_guids.Contains(key1.id));
            Assert.IsTrue(key_guids.Contains(key2.id));
            Assert.IsTrue(key_guids.Contains(key3.id));
        }
    }
}
