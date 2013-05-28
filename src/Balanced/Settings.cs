using System;
using System.Reflection;

namespace Balanced
{
    public static class Settings
    {
        public static string Agent = "balanced-csharp";

        public static string Version = Assembly.GetCallingAssembly().GetName().Version.ToString(3);

        public static string Location = "https://api.balancedpayments.com";

        public static string Secret;

        public static void configure(string secret)
        {
            Secret = secret;
        }

        public static void configure(string secret, string location)
        {
            Secret = secret;
            Location = location;
        }
    }
}
