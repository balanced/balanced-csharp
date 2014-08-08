using Balanced;
using System.Collections.Generic;

Balanced.Balanced.configure("ak-test-DXIgzoqwN4LsoCabloqy87y42qwm1lXR");

Credit credit = Credit.Fetch("{{ uri }}");
Dictionary<string, string> meta = new Dictionary<string, string>();
meta.Add("facebook.id", "{{ payload.meta.["facebook.id"] }}");
meta.Add("anykey", "{{ payload.meta.["anykey"] }}");
credit.meta = meta;
credit.Save();
