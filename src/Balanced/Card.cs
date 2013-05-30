using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Balanced
{
    public class Card : Resource
    {
        public class Collection : ResourceCollection<Card>
        {
            public Collection(string uri)
                : base(uri)
            { }

            public Card Create(
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
                var i = new Card()
                { 
                    StreetAddress = streetAddress,
                    PostalCode = postalCode,
                    Name = name,
                    ExpirationMonth = expirationMonth,
                    ExpirationYear = expirationYear
                };
                Dictionary<string, object> data = new Dictionary<string, object>();
                data["city"] = city;
                data["region"] = region;
                data["card_number"] = cardNumber;
                data["security_code"] = securityCode;
                i.Serialize(data);
                return base.Create(data);
            }
        }

        public string Id;

        public DateTime CreatedAt;

        public Dictionary<string, string> Meta;

        public string StreetAddress;

        public string PostalCode;

        public string CountryCode;

        public string Name;

        public long ExpirationMonth;

        public long ExpirationYear;

        public string LastFour;

        public string Brand;

        public Boolean IsValid;

        public string Fingerprint;

        public void invalidate()
        {
            IsValid = false;
            Save();
        }

        public override void Serialize(IDictionary<string, object> data)
        {
            base.Serialize(data);

            data["meta"] = Meta;
            data["street_address"] = StreetAddress;
            data["postal_code"] = PostalCode;
            data["country_code"] = CountryCode;
            data["name"] = Name;
            data["expiration_month"] = ExpirationMonth;
            data["expiration_year"] = ExpirationYear;
            data["last_four"] = LastFour;
            data["brand"] = Brand;
            data["is_valid"] = IsValid;
        }

        public override void Deserialize(IDictionary<string, object> data)
        {
            base.Deserialize(data);

            Id = (string)data["id"];
            Deserialize(data["created_at"], out CreatedAt);
            Deserialize(data["meta"], out Meta);
            StreetAddress = (string)data["street_address"];
            PostalCode = (string)data["postal_code"];
            CountryCode = (string)data["country_code"];
            Name = (string)data["name"];
            ExpirationMonth = (long)data["expiration_month"];
            ExpirationYear = (long)data["expiration_year"];
            LastFour = (string)data["last_four"];
            Brand = (string)data["brand"];
            IsValid = (bool)data["is_valid"];
            Fingerprint = (string)data["hash"];
        }
    }
}
