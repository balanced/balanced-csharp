using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Balanced
{
    public class APIKey : Resource
    {
        public static ResourceQuery<APIKey> Query
        {
            get
            {
                return new ResourceQuery<APIKey>("/v1/api_keys");
            }
        }

        public string Id;

        public DateTime CreatedAt;

        public Dictionary<string, string> Meta = new Dictionary<string, string>();

        public string Secret;

        public override string RootUri
        {
            get
            {
                return "/v1/api_keys";
            }
        }
        
        public override void Serialize(IDictionary<string, object> data)
        {
            base.Serialize(data);
            data["meta"] = Meta;
        }

        public override void Deserialize(IDictionary<string, object> data)
        {
            base.Deserialize(data);
            Id = (string)data["id"];
            Deserialize(data["created_at"], out CreatedAt);
            Deserialize(data["meta"], out Meta);
            Secret = data.ContainsKey("secret") ? (string)data["secret"] : null;
        }
    }
}
