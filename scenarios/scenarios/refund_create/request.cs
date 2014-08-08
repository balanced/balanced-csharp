using Balanced;
using System.Collections.Generic;

Balanced.Balanced.configure("ak-test-DXIgzoqwN4LsoCabloqy87y42qwm1lXR");

Debit debit = Debit.Fetch("{{debit_href}}");
Dictionary<string, string> payload = new Dictionary<string, string>();
payload.Add("amount", {{ payload.amount}});
payload.Add("description", "{{ payload.description }}");
Refund refund = debit.Refund(payload);