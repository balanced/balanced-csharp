using System;
using System.Collections.Generic;
using System.Linq;

namespace Balanced
{
    public class BankAccount : Resource
    {
        public static ResourceQuery<Marketplace> Query
        {
            get
            {
                return new ResourceQuery<Marketplace>(typeof(Marketplace), RootUri);
            }
        }

        public class Collection : ResourceCollection<BankAccount>
        {
            public Collection(string uri) : base(typeof(BankAccount), uri) {}

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

        public const string Checking = "checking";
        public const string Savings = "savings";
        public string Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public Dictionary<string, string> Meta { get; set; }
        public string Name { get; set; }
        public string AccountNumber { get; set; }
        public string RoutingNumber { get; set; }
        public string Type { get; set; }
        public string Fingerprint { get; set; }
        public string BankName { get; set; }
        public string VerificationsUri { get; set; }
        public BankAccountVerification.Collection Verifications { get; set; }
        public string VerificationUri { get; set; }
        
        protected static String RootUri = "/v" + Settings.Version + "/bank_accounts"; 

        public override void Serialize(IDictionary<string, object> data)
        {
            base.Serialize(data);

            data["meta"] = Meta;
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

        public override void Save()
        {
            if (Id == null && Uri == null)
            {
                Uri = RootUri;
            }
            base.Save();
        }

        public BankAccountVerification GetVerification()
        {
            if (VerificationUri == null)
            {
                return null;
            }
            return new BankAccountVerification(VerificationUri);
        }
    }
}
