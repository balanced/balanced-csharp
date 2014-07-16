using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace Balanced
{
    public static class Balanced
    {
        public static string VERSION { get { return "1.0";  } }
        public static string API_REVISION { get { return "1.1"; } }
        public static string API_URL { get { return "https://api.balancedpayments.com"; } }
        internal static string API_KEY { get; set; }

        public static void configure(string apiKey)
        {
            API_KEY = apiKey;
        }
    }
}
