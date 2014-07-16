using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Balanced.Exceptions
{
    public class HTTPException : Exception
    {
        public long status_code { get; set; }
        public string status { get; set; }

        public HTTPException() : base() { }
        public HTTPException(string message) : base(message) { }
        public HTTPException(string message, Exception e) : base(message, e) { }

        public HTTPException(HttpWebResponse response, string responsePayload)
        {
            status_code = (int)response.StatusCode;
            status = responsePayload;

        }
    }
}
