using Balanced;
using System.Collections.Generic;

Balanced.Balanced.configure("ak-test-DXIgzoqwN4LsoCabloqy87y42qwm1lXR");

Debit debit = Debit.Fetch("{{ uri }}");
Dictionary<string, string> meta = new Dictionary<string, string>();
meta.Add("anykey", "{{ payload.meta.["anykey"] }}");
debit.meta = meta;
debit.description = "{{payload.description}}";
debit.Save();