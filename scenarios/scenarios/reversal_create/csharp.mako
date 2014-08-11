% if mode == 'definition':
Credit.Reverse()
% elif mode == 'request':
using Balanced;
using System.Collections.Generic;

Balanced.Balanced.configure("ak-test-25ZY8HQwZPuQtDecrxb671LilUya5t5G0");

Credit credit = Credit.Fetch("/credits/CR5DQV6PdifnxDMmethpLIGN");
Dictionary<string, string> payload = new Dictionary<string, string>();
payload.Add("amount", 3000);
payload.Add("description", "Reversal for Order #1111");
Reversal reversal = credit.Reverse(payload);
% endif
