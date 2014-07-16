using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Balanced
{
    public abstract class FundingInstrument : Resource
    {
        // attributes
        [ResourceField(serialize = false)]
        public bool can_credit { get; set; }
        [ResourceField(serialize = false)]
        public bool can_debit { get; set; }
        [ResourceField(serialize = false)]
        public string bank_name { get; set; }
        [ResourceField(serialize = false)]
        public string fingerprint { get; set; }

        public abstract Debit Debit(Dictionary<string, object> payload);
        public abstract Credit Credit(Dictionary<string, object> payload);
    }
}
