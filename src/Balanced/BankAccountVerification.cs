using System;
using System.Collections.Generic;
using System.Linq;

namespace Balanced
{
    public class BankAccountVerification : Resource
    {
        public class Collection : ResourceCollection<BankAccountVerification>
        {
            public Collection(string uri) : base(uri) {}

            public BankAccountVerification Create()
            {
                return base.Create(new Dictionary<string, object>());
            }
        }

        public const string pending = "pending";
        public const string failed = "failed";
        public const string verified = "verified";
        public long attempts { get; set; }
        public long remaining_attempts { get; set; }
        public string state { get; set; }

        public BankAccountVerification() : base() {}

        public BankAccountVerification(string uri) : base(uri) {}

        public BankAccountVerification(IDictionary<string, object> payload) : base(payload) {}

        public override void Deserialize(IDictionary<string, object> data)
        {
            base.Deserialize(data);
        }

        public void Confirm(int amount_1, int amount_2)
        {
            var data = new Dictionary<string, object>();
            data["amount_1"] = amount_1;
            data["amount_2"] = amount_2;
            Deserialize((IDictionary<string, object>)Client.Put(uri, data));
        }
    }
}
