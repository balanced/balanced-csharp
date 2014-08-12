using Balanced;
using System.Collections.Generic;

Balanced.Balanced.configure("ak-test-DXIgzoqwN4LsoCabloqy87y42qwm1lXR");

Refund refund = Refund.Fetch("{{uri}}");
Dictionary<string, string> meta = new Dictionary<string, string>();
meta.Add("refund.reason", "{{ payload.meta.["refund.reason"] }}");
meta.Add("user.notes", "{{ payload.meta.["user.notes"] }}");
meta.Add("user.refund.count", "{{ payload.meta.["user.refund.count"] }}");
refund.meta = meta;
refund.description = "{{payload.description}}";
refund.Save();