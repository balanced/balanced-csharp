% if mode == 'definition':
Credit.Reverse()
% elif mode == 'request':
using Balanced;
using System.Collections.Generic;

Balanced.Balanced.configure("ak-test-1xLFE6RLC1W3P4ePiQDI4UVpRwtKcdfqL");

Credit credit = Credit.Fetch("/credits/CR5wJCGIh24U6yzbDGmWlMhL");
Dictionary<string, string> payload = new Dictionary<string, string>();
payload.Add("amount", 3000);
payload.Add("description", "Reversal for Order #1111");
Reversal reversal = credit.Reverse(payload);
% endif
