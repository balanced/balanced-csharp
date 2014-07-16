using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balanced
{
    public class ResourcePagination<T> : IEnumerable
    {
        //private string href;
        private ResourceIterator iterator;
        protected UriBuilder uri_builder;

        /*protected UriBuilder GetURIBuilder()
        {
            return uri_builder;
        }*/

        public ResourcePagination(string pHref)
        {
            //href = pHref;
            uri_builder = new UriBuilder();
            uri_builder.Path = pHref;
        }

        public IEnumerator GetEnumerator()
        {
            string href = GetURI();
            ResourcePage<T> page = new ResourcePage<T>(href);
            iterator = new ResourceIterator(href, page);
            return iterator;
        }

        public int Total()
        {
            if (iterator == null)
                this.GetEnumerator();
            return iterator.Total();
        }

        protected string GetURI()
        {
            var uri = uri_builder.Path.ToString() + uri_builder.Query.ToString();
            return uri;
        }

        public T First()
        {
            uri_builder.SetQueryParam("limit", "1");
            List<T> items = All();
            if (items.Count() == 0)
                return default(T);
            return items[0];
        }

        public List<T> All()
        {
            string href = GetURI();
            ResourcePage<T> page = new ResourcePage<T>(href);
            List<T> items = new List<T>(page.GetTotal());
            ResourceIterator iterator = new ResourceIterator(href, page);
            while (iterator.MoveNext())
            {
                object obj = iterator.Current;
                items.Add((T)obj);
            }
            return items;
        }

        public T Create()
        {
            Dictionary<string, object> payload = new Dictionary<string, object>();
            return Create(payload);
        }

        public T Create(Dictionary<string, object> payload)
        {
            dynamic resource;
            resource = Client.Post<T>(GetURI(), Resource.Serialize(payload));
            return resource;
        }

        public class ResourceIterator : IEnumerator
        {
            private String href;
            private ResourcePage<T> page;
            private int index;

            public ResourceIterator(String pHref, ResourcePage<T> pPage)
            {
                href = pHref;
                page = pPage;
                index = 0;
            }

            public object Current
            {
                get
                {
                    if (index >= page.GetSize())
                    {
                        page = page.GetNext();
                        index = 0;
                    }
                    T t = page.GetItems()[index];
                    index += 1;
                    return t;
                }
            }

            public bool MoveNext()
            {
                return (index < page.GetSize() || this.page.GetNextUri() != null);
            }

            public int Total()
            {
                return page.GetTotal();
            }

            public void Reset()
            {
                throw new NotImplementedException();
            }
        }
    }
}
