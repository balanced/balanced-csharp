using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balanced
{
    public class ResourcePage<T>
    {
        public string href;
        private List<T> items;
        private int total;
        private string first_uri;
        private string previous_uri;
        private string next_uri;
        private string last_uri;
    
        public ResourcePage(
                string pHref,
                List<T> pItems,
                int pTotal,
                string pFirst_uri,
                string pPrevious_uri,
                string pNext_uri,
                string pLast_uri)
        {
            href = pHref;
            items = pItems;
            total = pTotal;        
            first_uri = pFirst_uri;
            previous_uri = pPrevious_uri;
            next_uri = pNext_uri;
            last_uri = pLast_uri;
        }
    
        public ResourcePage(string pHref)
        {
            href = pHref;
        }
    
        public int GetSize()
        {
            return GetItems().Count();
        }
    
        public List<T> GetItems()
        {
            if (items == null) 
                Load();
            return items;
        }
    
        public string GetFirstUri()
        {
            if (items == null) 
                Load();
            return first_uri;
        }
    
        public ResourcePage<T> GetFirst()
        {
            return new ResourcePage<T>(GetFirstUri());
        }
    
        public string GetPreviousUri()
        {
            if (items == null) 
                Load();
            return previous_uri;
        }
    
        public ResourcePage<T> GetPrevious()
        {
            return new ResourcePage<T>(GetPreviousUri());
        }
    
        public string GetNextUri()
        {
            if (items == null) 
                Load();
            return next_uri;
        }
    
        public ResourcePage<T> GetNext()
        {
            return new ResourcePage<T>(GetNextUri());
        }
    
        public String GetLastUri()
        {
            return last_uri;
        }
    
        public ResourcePage<T> GetLast()
        {
            return new ResourcePage<T>(GetLastUri());
        }

    
        public int GetTotal()
        {
            if (items == null) 
                Load();
            return total;
        }
    
        internal void Load()
        {
            string responsePayload = Client.Get<Dictionary<string, object>>(href, false);
            var responseObject = JObject.Parse(responsePayload);
            IList<string> keys = responseObject.Properties().Select(p => p.Name).ToList();
            Dictionary<string, object> meta = null;
            Dictionary<string, string> hyperlinks = null;

            if (responseObject["meta"] != null)
                meta = responseObject["meta"].ToObject<Dictionary<string, object>>();

            if (responseObject["links"] != null)
                hyperlinks = responseObject["links"].ToObject<Dictionary<string, string>>();

            items = new List<T>();

            foreach (string key in keys)
            {
                // ignore links and meta
                if (key.Equals("links") || key.Equals("meta"))
                    continue;

                List<JObject> objs = responseObject[key].ToObject<List<JObject>>();
                foreach (JObject o in objs)
                {
                    var cust = o.ToObject<T>();
                    items.Add(cust);
                }
            }

            href = (string)meta["href"];
            total = Convert.ToInt32(meta["total"]);
            first_uri = (string)meta["first"];
            last_uri = (string)meta["last"];
            previous_uri = (string)meta["previous"];
            next_uri = (string)meta["next"];
        }
    }
}
