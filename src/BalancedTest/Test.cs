using Balanced;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalancedTest
{
    [TestClass]
    public class Test
    {
        protected static String Location = "https://api.balancedpayments.com";

        protected static String Secret = "fbb068c6c76e11e2b025026ba7f8ec28";

        protected static Marketplace Mine;

        protected BankAccount CreateBankAccount(Marketplace mp)
        {
            if (mp == null)
                mp = Mine;
            return mp.TokenizeBankAccount(
                "Homer Jay",
                "112233a",
                "121042882");
        }

        static Test()
        {
            String location = Environment.GetEnvironmentVariable("BALANCED_LOCATION");
            if (location != null)
                Location = location;
            String secret = Environment.GetEnvironmentVariable("BALANCED_SECRET");
            if (secret != null)
                Secret = secret;
            Settings.configure(Secret, Location);
            Mine = Marketplace.Mine;
        }

        [TestInitialize]
        public void Initialize()
        {
            Settings.configure(Secret, Location);
        }
    }
}
