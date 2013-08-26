using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Balanced
{
    public class Card : Resource
    {
        public Card() : base() { }

        public Card(string uri) : base(uri) {}

        public class Collection : ResourceCollection<Card>
        {
            public Collection(string uri)
                : base(uri)
            { }

            public Card Create(
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
                var i = new Card() 
                { 
                    street_address = street_address,
                    postal_code = postal_code,
                    name = name,
                    expiration_month = expiration_month,
                    expiration_year = expiration_year
                };
                Dictionary<string, object> data = new Dictionary<string, object>();
                data["city"] = city;
                data["region"] = region;
                data["card_number"] = card_number;
                data["security_code"] = security_code;
                i.Serialize(data);
                return base.Create(data);
            }
        }

        public DateTime created_at { get; set; }
        public IDictionary<string, object> meta { get; set; }
        public string street_address { get; set; }
        public string postal_code { get; set; }
        public string country_code { get; set; }
        public string name { get; set; }
        public long expiration_month { get; set; }
        public long expiration_year { get; set; }
        public string last_four { get; set; }
        public string brand { get; set; }
        public Boolean is_valid { get; set; }
        public string fingerprint { get; set; }

        public void invalidate()
        {
            is_valid = false;
            Save();
        }

        public override void Serialize(IDictionary<string, object> data)
        {
            base.Serialize(data);

            data["meta"] = meta;
            data["street_address"] = street_address;
            data["postal_code"] = postal_code;
            data["country_code"] = country_code;
            data["name"] = name;
            data["expiration_month"] = expiration_month;
            data["expiration_year"] = expiration_year;
            data["last_four"] = last_four;
            data["brand"] = brand;
            data["is_valid"] = is_valid;
        }

        public override void Deserialize(IDictionary<string, object> data)
        {
            base.Deserialize(data);
        }
    }
}
