using System;
using System.Collections.Generic;
using System.Linq;

namespace Balanced
{
    public class BankAccount : Resource
    {
        public static ResourceQuery<BankAccount> Query
        {
            get
            {
                return new ResourceQuery<BankAccount>("/v1/bank_accounts");
            }
        }

        public class Collection : ResourceCollection<BankAccount> 
        {
            public Collection(string uri) : base(uri)
            { }

            public BankAccount Create(string name, string accountNumber, string routingNumber)
            {
                var i = new BankAccount();
                i.Name = name;
                i.AccountNumber = accountNumber;
                i.RoutingNumber = routingNumber;
                Dictionary<string, object> data = new Dictionary<string, object>();
                i.Serialize(data);
                return base.Create(data);
            }
        }

        public string Id;

        public DateTime CreatedAt;

        public Dictionary<string, string> Meta;

        public string Name;

        public string AccountNumber;

        public string RoutingNumber;

        public string Type;

        public string Fingerprint;

        public string BankName;

        public string VerificationsUri;

        public BankAccountVerification.Collection Verifications;

        public string VerificationUri;

        public override string RootUri
        {
            get
            {
                return "/v1/bank_accounts";
            }
        }

        public override void Serialize(IDictionary<string, object> data)
        {
            base.Serialize(data);

            data["name"] = Name;
            data["account_number"] = AccountNumber;
            data["routing_number"] = RoutingNumber;
            if (Type != null)
                data["type"] = Type;
        }

        public override void Deserialize(IDictionary<string, object> data)
        {
            base.Deserialize(data);

            Id = (string)data["id"];
            Deserialize(data["created_at"], out CreatedAt);
            Deserialize(data["meta"], out Meta);
            Name = (string)data["name"];
            AccountNumber = (string)data["account_number"];
            RoutingNumber = (string)data["routing_number"];
            Type = (string)data["type"];
            Fingerprint = (string)data["fingerprint"];
            BankName = (string)data["bank_name"];
            VerificationsUri = (string)data["verifications_uri"];
            Verifications = new BankAccountVerification.Collection(VerificationsUri);
            VerificationUri = (string)data["verification_uri"];
        }

        public BankAccountVerification Verify()
        {
            return Verifications.Create();
        }
    }
}
