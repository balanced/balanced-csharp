using System; 
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Balanced;
using System.Collections.Generic;

namespace BalancedTest
{
    [TestClass]
    public class TestResource
    {
        [TestMethod]
        public void TestResourceDeserialize()
        {
            IDictionary<string, object> Payload = new Dictionary<string, object>();
            Payload["id"] = 1;
            Payload["description"] = "fake description";
            Payload["country_code"] = "USA";
            Payload["is_valid"] = false;
            Payload["uri"] = null;

            Foo foo = new Foo();
            foo.Deserialize(Payload);

            Assert.AreEqual(1, foo.Id);
            Assert.AreEqual("fake description", foo.Description);
            Assert.AreEqual("USA", foo.CountryCode);
            Assert.AreEqual(false, foo.IsValid);
        }
    }
    public class Foo : Resource
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string CountryCode { get; set; }
        public Boolean IsValid { get; set; }
        public string URI { get; set; }
        public Foo() : base() { }
    }
}
