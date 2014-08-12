using Balanced;
using System.Collections.Generic;

Balanced.Balanced.configure("{{ api_key }}");

Debit debit = Debit.Fetch("{{ uri }}");
Dictionary<string, string> meta = new Dictionary<string, string>();
meta.Add("anykey", "{{ payload.meta.["anykey"] }}");
debit.meta = meta;
debit.description = "{{payload.description}}";
debit.Save();