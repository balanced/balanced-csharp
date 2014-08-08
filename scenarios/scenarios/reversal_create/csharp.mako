% if mode == 'definition':
Credit.Reverse()
% elif mode == 'request':
using Balanced;

Balanced.Balanced.configure("ak-test-DXIgzoqwN4LsoCabloqy87y42qwm1lXR");

Credit credit = Credit.Fetch("/credits/CR3cR2U2FK754357DNSpOfVX");
Dictionary<string, string> payload = new Dictionary<string, string>();
payload.Add("amount", 3000);
payload.Add("description", "Reversal for Order #1111");
Reversal reversal = credit.Reverse(payload);
% endif
