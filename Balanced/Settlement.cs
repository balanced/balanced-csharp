using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balanced
{
    public class Settlement : Resource
    {
        [JsonIgnore]
        public static string resource_href
        {
            get { return "/settlements"; }
        }

        [ResourceField(field = "settlements.events", link = true, serialize = false)]
        public Event.Collection events { get; set; }

        public static Settlement Fetch(string href)
        {
            return Resource.Fetch<Settlement>(href);
        }

        public class Collection : ResourceCollection<Settlement>
        {
            public Collection() : base(resource_href) { }
            public Collection(string href) : base(href) { }
        }

        public static ResourceQuery<Settlement> Query()
        {
            return new ResourceQuery<Settlement>(resource_href);
        }
    }
}
