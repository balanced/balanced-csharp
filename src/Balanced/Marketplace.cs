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

        public string name;
        public string support_email_addresses;
        public string support_phone_number;
        public string domain_url;
        public long in_escrow;
        BankAccount.Collection BankAccounts;
        Card.Collection Cards;
        public string customers_uri;
        public string debits_uri;
        public string credits_uri;
        public string holds_uri;
        public string refunds_uri;
        public string events_uri;
        public string callbacks_uri;

        public override string root_uri
        {
            get
            {
                return "/v1/marketplaces";
            }
        }

        public override void Serialize(IDictionary<string, object> data)
        {
            base.Serialize(data);

            if (name != null)
                data["name"] = name;
            if (support_email_addresses != null)
                data["support_email_address"] = support_email_addresses;
            if (support_phone_number != null)
                data["support_phone_number"] = support_phone_number;
            if (domain_url != null)
                data["domain_url"] = domain_url;
        }

        public override void Deserialize(IDictionary<string, object> data)
        {
            base.Deserialize(data);
            
            id = (string)data["id"];
            name = (string)data["name"];
            support_email_addresses = (string)data["support_email_address"];
            support_phone_number = (string)data["support_phone_number"];
            domain_url = (string)data["domain_url"];
            in_escrow = (long)data["in_escrow"];
            BankAccounts = new BankAccount.Collection((string)data["bank_accounts_uri"]);
            Cards = new Card.Collection((string)data["cards_uri"]);
        }

        public BankAccount TokenizeBankAccount(string name, string accountNumber, string routingNumber)
        {
            return BankAccounts.Create(name, accountNumber, routingNumber);
        }

        public Card TokenizeCard(
            string street_address,
            string city,
            string region,
            string postal_code,
            string name,
            string card_number,
            string security_code,
            int expiration_month,
            int expiration_year
            )
        {
            return Cards.Create(
                street_address,
                city,
                region,
                postal_code,
                name,
                card_number,
                security_code,
                expiration_month,
                expiration_year
            );
        }
    }
}
