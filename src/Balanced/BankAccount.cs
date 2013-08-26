using System;
using System.Collections.Generic;
using System.Linq;

namespace Balanced
{
    public class BankAccount : Resource
    {

        public const string checking = "checking";
        public const string savings = "savings";
        public DateTime created_at { get; set; }
        public IDictionary<string, object> meta { get; set; }
        public string name { get; set; }
        public string account_number { get; set; }
        public string routing_number { get; set; }
        public string type { get; set; }
        public string fingerprint { get; set; }
        public string bank_name { get; set; }
        public string verification_uri { get; set; }
        public string verifications_uri { get; set; }

        public BankAccountVerification.Collection Verifications { get; set; }

        public override string root_uri { get { return "/v1/bank_accounts"; } }

        public static ResourceQuery<Marketplace> Query
        {
            get
            {
                return new ResourceQuery<Marketplace>(typeof(Marketplace), "/v1/bank_accounts");
            }
        }

        public class Collection : ResourceCollection<BankAccount>
        {
            public Collection(string uri) : base(typeof(BankAccount), uri) {}

            public BankAccount Create(string name, string accountNumber, string routingNumber)
            {
                var i = new BankAccount();
                i.name = name;
                i.account_number = accountNumber;
                i.routing_number = routingNumber;
                Dictionary<string, object> data = new Dictionary<string, object>();
                i.Serialize(data);
                return base.Create(data);
            }
        }

        public BankAccount() : base() {}
        public BankAccount(string uri) : base(uri) { }
        public BankAccount(Dictionary<String, Object> payload) : base(payload) { }

        public override void Serialize(IDictionary<string, object> data)
        {
            base.Serialize(data);
            data["meta"] = meta;
            data["name"] = name;
            data["account_number"] = account_number;
            data["routing_number"] = routing_number;
            if (type != null)
                data["type"] = type;
        }

        public override void Deserialize(IDictionary<string, object> data)
        {
            base.Deserialize(data);
            Verifications = new BankAccountVerification.Collection(verifications_uri);
        }

        public BankAccountVerification Verify()
        {
            return Verifications.Create();
        }

        public override void Save()
        {
            base.Save();
        }

        public BankAccountVerification GetVerification()
        {
            if (verification_uri == null)
            {
                return null;
            }
            return new BankAccountVerification(verification_uri);
        }
    }
}
