using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balanced
{
    public class Dispute : Resource
    {
        [JsonIgnore]
        public static string resource_href
        {
            get { return "/disputes"; }
        }

        // attributes
        [ResourceField]
        public int amount { get; set; }
        [ResourceField]
        public string currency { get; set; }
        [ResourceField]
        public DateTime initiated_at { get; set; }
        [ResourceField]
        public string reason { get; set; }
        [ResourceField]
        public DateTime respond_by { get; set; }
        [ResourceField]
        public string status { get; set; }

        [ResourceField(field = "disputes.events", link = true, serialize = false)]
        public Event.Collection events { get; set; }

        [ResourceField(field = "disputes.transaction", link = true, serialize = false)]
        public Debit transaction { get; set; }


        public static Dispute Fetch(string href)
        {
            return Resource.Fetch<Dispute>(href);
        }

        public class Collection : ResourceCollection<Dispute>
        {
            public Collection() : base(resource_href) { }
            public Collection(string href) : base(href) { }
        }

        public static ResourceQuery<Dispute> Query()
        {
            return new ResourceQuery<Dispute>(resource_href);
        }
    }
}
