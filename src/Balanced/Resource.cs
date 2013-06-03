using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Web;


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

        public virtual string RootUri
        {
            get
            {
                return null;
            }
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

        public string Uri;

        public virtual void Save()
        {
            if (Uri != null)
            {
                Dictionary<string, object> data = new Dictionary<string, object>();
                Serialize(data);
                Deserialize(Client.Put(Uri, data));
            }
            else
            {
                if (RootUri == null)
                {
                    throw new Exception("Cannot create top level");
                }
                Dictionary<string, object> data = new Dictionary<string, object>();
                Serialize(data);
                Deserialize(Client.Post(RootUri, data));
            }
        }

        public virtual void Delete()
        {
            client.Delete(Uri);
        }

        public virtual void Refresh()
        {
            if (Uri == null)
                throw new Exception("Cannot refresh before creation");
            Deserialize(client.Get(Uri));
        }

        public virtual void Serialize(IDictionary<string, object> data)
        {
        }

        public virtual void Deserialize(IDictionary<string, object> data)
        {
            Uri = (String)data["uri"];

            System.Reflection.PropertyInfo[] Properties = this.GetType().GetProperties();
            IEnumerable<string> PropertyNames = from x in Properties select x.Name;
            IDictionary<string, string> PropertyNameLookup = new Dictionary<string, string>();
            foreach (string PropertyName in PropertyNames)
            {
                PropertyNameLookup[Utilities.ConvertToPythonCase(PropertyName)] = PropertyName;
            }
            foreach (KeyValuePair<string, object> entry in data)
            {
                if (PropertyNameLookup.Keys.Any(x => x == entry.Key))
                {
                    this.GetType().GetProperty(PropertyNameLookup[entry.Key]).SetValue(this, entry.Value);
                }
            }
        }

        protected void Deserialize(object src, out Dictionary<string, string> dst)
        {
            dst = ((IDictionary<string, object>)src).ToDictionary(kv => kv.Key, kv => (string)kv.Value);

            System.Reflection.PropertyInfo[] Properties = this.GetType().GetProperties();
            IEnumerable<string> PropertyNames = from x in Properties select x.Name;
            IDictionary<string, string> PropertyNameLookup = new Dictionary<string, string>();
            foreach (string PropertyName in PropertyNames)
            {
                PropertyNameLookup[Utilities.ConvertToPythonCase(PropertyName)] = PropertyName;
            }
            foreach (KeyValuePair<string, string> entry in dst)
            {
                if (PropertyNameLookup.Keys.Any(x => x == entry.Key))
                {
                    this.GetType().GetProperty(PropertyNameLookup[entry.Key]).SetValue(this, entry.Value);
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
            Uri = uri;
        }

        public ResourcePage(IDictionary<string, object> data)
        {
            Deserialize(data);
        }

        public string Uri;
        public List<T> _Items;
        public long _Total;
        public string _FirstUri;
        public string _PreviousUri;
        public string _NextUri;
        public string _LastUri;
        protected Client _Client;

        public Client Client
        {
            get
            {
                if (_Client == null)
                    _Client = new Client();
                return _Client;
            }
        }

        public List<T> Items
        {
            get
            {
                if (!Loaded)
                    Load();
                return _Items;
            }
        }

        public long Total
        {
            get
            {
                if (!Loaded)
                    Load();
                return _Total;
            }
        }

        public string FirstUri
        {
            get
            {
                if (!Loaded)
                    Load();
                return _FirstUri;
            }
        }

        public ResourcePage<T> First
        {
            get
            {
                if (FirstUri == null)
                    return null;
                return new ResourcePage<T>(FirstUri);
            }
        }

        public string PreviousUri
        {
            get
            {
                if (!Loaded)
                    Load();
                return _PreviousUri;
            }
        }

        public ResourcePage<T> Previous
        {
            get
            {
                if (PreviousUri == null)
                    return null;
                return new ResourcePage<T>(PreviousUri);
            }
        }

        public string NextUri
        {
            get
            {
                if (!Loaded)
                    Load();
                return _NextUri;
            }
        }

        public ResourcePage<T> Next
        {
            get
            {
                if (NextUri == null)
                    return null;
                return new ResourcePage<T>(NextUri);
            }
        }

        public string LastUri
        {
            get
            {
                if (!Loaded)
                    Load();
                return _LastUri;
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
                return _Items != null;
            }
        }

        protected void Load()
        {
            Deserialize(Client.Get(Uri));
        }

        protected virtual void Deserialize(IDictionary<string, object> data)
        {
            Uri = (string)data["uri"];
            _Items = ((IList<object>)data["items"]).Select(v => DeserializeItem((IDictionary<string, object>)v)).ToList();
            _FirstUri = (string)data["first_uri"];
            _PreviousUri = (string)data["previous_uri"];
            _NextUri = (string)data["next_uri"];
            _LastUri = (string)data["last_uri"];
            _Total = (long)data["total"];
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
        protected string Path;

        protected NameValueCollection Parameters;

        protected Client _Client;

        public Client Client
        {
            get
            {
                if (_Client == null)
                    _Client = new Client();
                return _Client;
            }
        }

        public ResourcePagination(string uri)
        {
            int i = uri.IndexOf('?');
            if (i == -1)
            {
                Path = uri;
                Parameters = HttpUtility.ParseQueryString(string.Empty);
            }
            else
            {
                Path = uri.Substring(0, i);
                Parameters = HttpUtility.ParseQueryString(uri.Substring(i));
            }

        }

        public string Uri
        {
            get
            {
                if (Parameters.Count == 0)
                {
                    return Path;
                }
                return Path + "?" + Parameters.ToString();
            }
        }

        public int? Limit
        {
            get
            {
                if (Parameters["limit"] == null)
                    return null;
                return int.Parse(Parameters["limit"]);
            }
            set
            {
                Parameters["limit"] = value.ToString();
            }
        }

        public long Total
        {
            get
            {
                int? limit = Limit;
                Limit = 1;
                ResourcePage<T> current = new ResourcePage<T>(Uri);
                long total = current.Total;
                Limit = limit;
                return total;
            }
        }


        public T First()
        {
            int? limit = Limit;
            Limit = 1;
            IList<T> items = All();
            Limit = limit;
            if (items.Count == 0)
                return null;
            return items[0];
        }

        public T One()
        {
            int? limit = Limit;
            Limit = 2;
            IList<T> items = All();
            Limit = limit;
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
            ResourcePage<T> current = new ResourcePage<T>(Uri);
            while (current != null)
            {
                foreach (T i in current.Items)
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
        public ResourceQuery(string uri)
            : base(uri)
        {
        }

        public ResourceQuery<T> Filter(string field, params object[] values)
        {
            string n = String.Format("{0}", field);
            string v = String.Join(",", new List<string>(Serialize(values)));
            Parameters.Add(n, v);
            return this;
        }

        public ResourceQuery<T> Filter(string field, string op, params object[] values)
        {
            string n = String.Format("{0}[{1}]", field, op);
            string v = String.Join(",", new List<string>(Serialize(values)));
            Parameters.Add(n, v);
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
            Parameters.Add("sort", field);
            return this;
        }


        public ResourceQuery<T> OrderBy(string field, ResourceQueryOrder direction)
        {
            string sort = String.Format("{0},{1}", field, direction == ResourceQueryOrder.ASCENDING ? "asc" : "desc");
            Parameters.Add("sort", sort);
            return this;
        }
    }

    public class ResourceCollection<T> : ResourcePagination<T>
        where T : Resource, new()
    {
        public ResourceCollection(string uri)
            : base(uri)
        {
        }

        public T Create(IDictionary<string, object> data)
        {
            IDictionary<string, object> result = (IDictionary<string, object>)Client.Post(Uri, data);
            T t = new T();
            t.Deserialize(result);
            return t;
        }

        public ResourceQuery<T> Query
        {
            get
            {
                return new ResourceQuery<T>(Uri);
            }
        }
    }
}
