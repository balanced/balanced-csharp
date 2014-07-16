using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balanced
{
    public class Event : Resource
    {
        [JsonIgnore]
        public static string resource_href
        {
            get { return "/events"; }
        }

        // attributes
        [ResourceField(serialize = false)]
        public DateTime occurred_at { get; set; }
        [ResourceField(serialize = false)]
        public string type { get; set; }
        [ResourceField(serialize = false)]
        public Dictionary<string, int> callback_statuses { get; set; }
        [ResourceField(serialize = false)]
        public Dictionary<string, object> entity { get; set; }
        [ResourceField(serialize = false)]
        public Callback.Collection callbacks { get; set; }

        public static Event Fetch(string href)
        {
            return Resource.Fetch<Event>(href);
        }

        public class Collection : ResourceCollection<Event>
        {
            public Collection() : base(resource_href) { }
            public Collection(string href) : base(href) { }
        }

        public static ResourceQuery<Event> Query()
        {
            return new ResourceQuery<Event>(resource_href);
        }
    }
}
