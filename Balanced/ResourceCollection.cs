using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balanced
{
    public class ResourceCollection<T> : ResourcePagination<T>
    {
        public ResourceCollection(string href) : base(href) { }

        public ResourceQuery<T> Query()
        {
            Type type = typeof(T);
            string resource_href = (string)type.GetProperty("resource_href").GetValue(null);
            return new ResourceQuery<T>(resource_href);
        }
    }
}
