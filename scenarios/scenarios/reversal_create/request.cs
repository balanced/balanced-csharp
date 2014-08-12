using Balanced;
using System.Collections.Generic;

Balanced.Balanced.configure("{{ api_key }}");

Credit credit = Credit.Fetch("{{credit_href}}");
Dictionary<string, string> payload = new Dictionary<string, string>();
payload.Add("amount", {{ payload.amount}});
payload.Add("description", "{{ payload.description}}");
Reversal reversal = credit.Reverse(payload);