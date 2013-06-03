using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balanced
{
    class Callback : Resource
    {
        public string Url { get; set; }
        public static class Collection : ResourceCollection<Callback>
        {
            public Collection(string uri) : base(typeof(Callback), uri) { }
            public Callback Create(string url)
            {
                Callback callback = new Callback();
                callback.Uri = this.Uri;
                callback.Url = url;
                callback.Save();
                return callback;
            }
        }
        public Callback() : base() { }
        public Callback(string uri) : base(uri) { }
        public Callback(IDictionary<string, object> payload) : base(payload) { }
    }
}
