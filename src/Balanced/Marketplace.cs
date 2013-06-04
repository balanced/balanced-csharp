using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Balanced
{
    public class Marketplace : Resource
    {
        public static Marketplace Mine
        {
            get
            {
                return Query.One();
            }
        }

        public static ResourceQuery<Marketplace> Query
        {
            get
            {
                return new ResourceQuery<Marketplace>("/v1/marketplaces");
            }
        }

        public string Id;
        public string Name;
        public string SupportEmailAddress;
        public string SupportPhoneNumber;
        public string DomainUrl;
        public long InEscrow;
        BankAccount.Collection BankAccounts;
        Card.Collection Cards;
        public string CustomersUri;
        public string DebitsUri;
        public string CreditsUri;
        public string HoldsUri;
        public string RefundsUri;
        public string EventsUri;
        public string CallbacksUri;

        public override string RootUri
        {
            get
            {
                return "/v1/marketplaces";
            }
        }

        public override void Serialize(IDictionary<string, object> data)
        {
            base.Serialize(data);

            if (Name != null)
                data["name"] = Name;
            if (SupportEmailAddress != null)
                data["support_email_address"] = SupportEmailAddress;
            if (SupportPhoneNumber != null)
                data["support_phone_number"] = SupportPhoneNumber;
            if (DomainUrl != null)
                data["domain_url"] = DomainUrl;
        }

        public override void Deserialize(IDictionary<string, object> data)
        {
            base.Deserialize(data);
            
            Id = (string)data["id"];
            Name = (string)data["name"];
            SupportEmailAddress = (string)data["support_email_address"];
            SupportPhoneNumber = (string)data["support_phone_number"];
            DomainUrl = (string)data["domain_url"];
            InEscrow = (long)data["in_escrow"];
            BankAccounts = new BankAccount.Collection((string)data["bank_accounts_uri"]);
            Cards = new Card.Collection((string)data["cards_uri"]);
        }

        public BankAccount TokenizeBankAccount(string name, string accountNumber, string routingNumber)
        {
            return BankAccounts.Create(name, accountNumber, routingNumber);
        }

        public Card TokenizeCard(
            string streetAddress,
            string city,
            string region,
            string postalCode,
            string name,
            string cardNumber,
            string securityCode,
            int expirationMonth,
            int expirationYear
            )
        {
            return Cards.Create(
                streetAddress,
                city,
                region,
                postalCode,
                name,
                cardNumber,
                securityCode,
                expirationMonth,
                expirationYear
            );
        }
    }
}
