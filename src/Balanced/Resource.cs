using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Web;
using System.Diagnostics;


namespace Balanced
{
    public class Resource
    {
        public Resource()
        { }

        public Resource(IDictionary<string, object> data)
        {
            Deserialize(data);
        }

        public Resource(string uri)
        {
            IDictionary<string, object> Payload = client.Get(uri);
            this.Deserialize(Payload);
        }

        public virtual string root_uri
        {
            get
            {
                return null;
            }
            set { }
        }

        protected Client client;

        public Client Client
        {
            get
            {
                if (client == null)
                    client = new Client();
                return client;
            }
        }

        public string uri;
        public string id;

        public virtual void Save()
        {
            if (uri == null && root_uri != null)
            {
                Dictionary<string, object> data = new Dictionary<string, object>();
                Serialize(data);
                Deserialize(Client.Post(root_uri, data));
            }
            else if (uri != null)
            {
                Dictionary<string, object> data = new Dictionary<string, object>();
                Serialize(data);
                Deserialize(Client.Put(uri, data));
            }
            else
            {
                if (root_uri == null)
                {
                    throw new Exception("Cannot create top level");
                }
                Dictionary<string, object> data = new Dictionary<string, object>();
                Serialize(data);
                Deserialize(Client.Post(root_uri, data));
            }
        }

        public virtual void Delete()
        {
            client.Delete(uri);
        }

        public virtual void Refresh()
        {
            if (uri == null)
                throw new Exception("Cannot refresh before creation");
            Deserialize(client.Get(uri));
        }

        public virtual void Serialize(IDictionary<string, object> data)
        {
        }

        public virtual void Deserialize(IDictionary<string, object> data)
        {
            uri = (String)data["uri"];

            System.Reflection.PropertyInfo[] Properties = this.GetType().GetProperties();
            IEnumerable<string> PropertyNames = from x in Properties select x.Name;
            foreach (KeyValuePair<string, Object> entry in data)
            {
                if (PropertyNames.Any(x => x == entry.Key))
                {
                    var clsProperty = this.GetType().GetProperty(entry.Key);
                    switch(clsProperty.PropertyType.Name)
                    {
                        case "DateTime":
                            {
                                DateTime dttm = DateTime.Parse((string)entry.Value, null, DateTimeStyles.RoundtripKind);
                                clsProperty.SetValue(this, dttm, null);
                                break;
                            }
                        case "Dictionary`2":
                            {
                                if (entry.Value != null && entry.Value.ToString() != "")
                                {
                                    var jsSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                                    clsProperty.SetValue(this, (Dictionary<string, object>)jsSerializer.DeserializeObject(entry.Value.ToString()), null);
                                }
                                 
                                break;
                            }
                        default:
                            {
                                clsProperty.SetValue(this, entry.Value, null);
                                break;
                            }

                    }
                }
            }
        }

        protected void Deserialize(object src, out Dictionary<string, string> dst)
        {
            dst = ((IDictionary<string, object>)src).ToDictionary(kv => kv.Key, kv => (string)kv.Value);

            System.Reflection.PropertyInfo[] Properties = this.GetType().GetProperties();
            IEnumerable<string> PropertyNames = from x in Properties select x.Name;
            foreach (KeyValuePair<string, string> entry in dst)
            {
                if (PropertyNames.Any(x => x == entry.Key))
                {
                    var clsProperty = this.GetType().GetProperty(entry.Key);
                    clsProperty.SetValue(this, entry.Value);
                }
            }
        }

        protected void Deserialize(object src, out DateTime dst)
        {
            dst = DateTime.Parse((string)src, null, DateTimeStyles.RoundtripKind);
        }
    }

    public class ResourcePage<T>
        where T : Resource, new()
    {
        public ResourcePage(string uri)
        {
            this.uri = uri;
        }

        public ResourcePage(IDictionary<string, object> data)
        {
            Deserialize(data);
        }

        public string uri;
        public List<T> _items;
        public long _total;
        public string _first_uri;
        public string _previous_uri;
        public string _next_uri;
        public string _last_uri;
        protected Client _client;

        public Client Client
        {
            get
            {
                if (_client == null)
                    _client = new Client();
                return _client;
            }
        }

        public List<T> items
        {
            get
            {
                if (!Loaded)
                    Load();
                return _items;
            }
        }

        public long total
        {
            get
            {
                if (!Loaded)
                    Load();
                return _total;
            }
        }

        public string first_uri
        {
            get
            {
                if (!Loaded)
                    Load();
                return _first_uri;
            }
        }

        public ResourcePage<T> first
        {
            get
            {
                if (first_uri == null)
                    return null;
                return new ResourcePage<T>(first_uri);
            }
        }

        public string previous_uri
        {
            get
            {
                if (!Loaded)
                    Load();
                return _previous_uri;
            }
        }

        public ResourcePage<T> Previous
        {
            get
            {
                if (previous_uri == null)
                    return null;
                return new ResourcePage<T>(previous_uri);
            }
        }

        public string next_uri
        {
            get
            {
                if (!Loaded)
                    Load();
                return _next_uri;
            }
        }

        public ResourcePage<T> Next
        {
            get
            {
                if (next_uri == null)
                    return null;
                return new ResourcePage<T>(next_uri);
            }
        }

        public string LastUri
        {
            get
            {
                if (!Loaded)
                    Load();
                return _last_uri;
            }
        }

        public ResourcePage<T> Last
        {
            get
            {
                if (LastUri == null)
                    return null;
                return new ResourcePage<T>(LastUri);
            }
        }

        protected bool Loaded
        {
            get
            {
                return _items != null;
            }
        }

        protected void Load()
        {
            Deserialize(Client.Get(uri));
        }

        protected virtual void Deserialize(IDictionary<string, object> data)
        {
            this.uri = (string)data["uri"];
            _items = ((IList<object>)data["items"]).Select(v => DeserializeItem((IDictionary<string, object>)v)).ToList();
            _first_uri = (string)data["first_uri"];
            _previous_uri = (string)data["previous_uri"];
            _next_uri = (string)data["next_uri"];
            _last_uri = (string)data["last_uri"];
            _total = (long)data["total"];
        }

        protected static T DeserializeItem(IDictionary<string, object> data)
        {
            T i = new T();
            i.Deserialize(data);
            return i;
        }
    }

    public class ResourcePagination<T> : IEnumerable<T>
        where T : Resource, new()
    {
        protected string path;
        protected NameValueCollection parameters;
        protected Client _client;
        protected Type cls;

        public Client Client
        {
            get
            {
                if (_client == null)
                    _client = new Client();
                return _client;
            }
        }

        public ResourcePagination(string uri)
        {
            int i = uri.IndexOf('?');
            if (i == -1)
            {
                path = uri;
                parameters = HttpUtility.ParseQueryString(string.Empty);
            }
            else
            {
                path = uri.Substring(0, i);
                parameters = HttpUtility.ParseQueryString(uri.Substring(i));
            }
        }
        public ResourcePagination(Type cls, string uri) 
        {
            this.cls = cls;
        }


        public string uri
        {
            get
            {
                if (parameters.Count == 0)
                {
                    return path;
                }
                return path + "?" + parameters.ToString();
            }
        }

        public int? limit
        {
            get
            {
                if (parameters["limit"] == null)
                    return null;
                return int.Parse(parameters["limit"]);
            }
            set
            {
                parameters["limit"] = value.ToString();
            }
        }

        public long total
        {
            get
            {
                int? limit = this.limit;
                limit = 1;
                ResourcePage<T> current = new ResourcePage<T>(uri);
                long total = current.total;
                this.limit = limit;
                return total;
            }
        }


        public T First()
        {
            int? limit = this.limit;
            this.limit = 1;
            IList<T> items = All();
            this.limit = limit;
            if (items.Count == 0)
                return null;
            return items[0];
        }

        public T One()
        {
            int? limit = this.limit;
            this.limit = 2;
            IList<T> items = All();
            this.limit = limit;
            if (items.Count == 0)
                throw new NoResultsFound();
            if (items.Count > 1)
                throw new MultipleResultsFound();
            return items[0];
        }

        public IList<T> All()
        {
            return new List<T>(this);
        }

        public IEnumerator<T> GetEnumerator()
        {
            ResourcePage<T> current = new ResourcePage<T>(uri);
            while (current != null)
            {
                foreach (T i in current.items)
                {
                    yield return i;
                }
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public enum ResourceQueryOrder
    {
        ASCENDING,
        DESCENDING,
    }

    public class ResourceQuery<T> : ResourcePagination<T>
        where T : Resource, new()
    {
        public ResourceQuery(string uri) : base(uri)  {}
        public ResourceQuery(Type cls, string uri) : base(cls, uri) {}

        public ResourceQuery<T> Filter(string field, params object[] values)
        {
            string n = String.Format("{0}", field);
            string v = String.Join(",", new List<string>(Serialize(values)));
            parameters.Add(n, v);
            return this;
        }

        public ResourceQuery<T> Filter(string field, string op, params object[] values)
        {
            string n = String.Format("{0}[{1}]", field, op);
            string v = String.Join(",", new List<string>(Serialize(values)));
            parameters.Add(n, v);
            return this;
        }

        protected IEnumerable<string> Serialize(object[] values)
        {
            foreach (object i in values)
            {
                yield return Serialize(i);
            }
        }

        protected string Serialize(object value)
        {
            if (value is string)
                return (string)value;
            if (value is DateTime)
                return ((DateTime)value).ToString("o");
            return value.ToString();
        }

        public ResourceQuery<T> OrderBy(string field)
        {
            parameters.Add("sort", field);
            return this;
        }

        public ResourceQuery<T> OrderBy(string field, ResourceQueryOrder direction)
        {
            string sort = String.Format("{0},{1}", field, direction == ResourceQueryOrder.ASCENDING ? "asc" : "desc");
            parameters.Add("sort", sort);
            return this;
        }
    }

    public class ResourceCollection<T> : ResourcePagination<T>
        where T : Resource, new()
    {
        public ResourceCollection(string uri) : base(uri)  {}

        public ResourceCollection(Type cls, string uri) : base(cls, uri) {}

        public T Create(IDictionary<string, object> data)
        {
            IDictionary<string, object> result = (IDictionary<string, object>)Client.Post(uri, data);
            T t = new T();
            t.Deserialize(result);
            return t;
        }

        public ResourceQuery<T> Query
        {
            get
            {
                return new ResourceQuery<T>(uri);
            }
        }
    }
}
