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

        public const string Pending = "pending";
        public const string Failed = "failed";
        public const string Verified = "verified";
        public string Id;
        public long Attempts;
        public long RemainingAttempts;
        public string State;
        public BankAccountVerification() : base() {}
        public BankAccountVerification(string uri) : base(uri) {}
        public BankAccountVerification(IDictionary<string, object> payload) : base(payload) {}
        public override void Deserialize(IDictionary<string, object> data)
        {
            base.Deserialize(data);

            Id = (string)data["id"];
            State = (string)data["state"];
            Attempts = (long)data["attempts"];
            RemainingAttempts = (long)data["remaining_attempts"];
        }

        public void Confirm(int amount_1, int amount_2)
        {
            var data = new Dictionary<string, object>();
            data["amount_1"] = amount_1;
            data["amount_2"] = amount_2;
            Deserialize((IDictionary<string, object>)Client.Put(Uri, data));
        }


    }
}
