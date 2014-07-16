using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Balanced.Exceptions
{
    public class APIException : HTTPException
    {
        public Dictionary<string, string> additional { get; set; }
        public string category_code { get; set; }
        public string category_type { get; set; }
        public string description { get; set; }
        public Dictionary<string, string> extras { get; set; }
        public string request_id { get; set; }
        //public string status { get; set; }
        //public int status_code { get; set; }

        public APIException() { }

        public APIException(
            HttpWebResponse response,
            Dictionary<string, object>responsePayload)
        {
            if (responsePayload.ContainsKey("additional") && responsePayload["additional"] != null)
                additional = ((JObject)responsePayload["additional"]).ToObject<Dictionary<string, string>>();
            category_code = responsePayload.ContainsKey("category_code") ? (string)responsePayload["category_code"] : null;
            category_type = responsePayload.ContainsKey("category_type") ? (string)responsePayload["category_type"] : null;
            description = responsePayload.ContainsKey("description") ? (string)responsePayload["description"] : null;
            if (responsePayload.ContainsKey("extras") && responsePayload["extras"] != null)
                additional = ((JObject)responsePayload["extras"]).ToObject<Dictionary<string, string>>();
            request_id = responsePayload.ContainsKey("request_id") ? (string)responsePayload["request_id"] : null;
            status = responsePayload.ContainsKey("status") ? (string)responsePayload["status"] : null;
            status_code = Convert.ToInt16(responsePayload["status_code"]);
        }
    }
}
