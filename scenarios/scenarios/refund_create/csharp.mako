% if mode == 'definition':
Debit.Refund()
% elif mode == 'request':
using Balanced;
using System.Collections.Generic;

Balanced.Balanced.configure("ak-test-25ZY8HQwZPuQtDecrxb671LilUya5t5G0");

Debit debit = Debit.Fetch("/debits/WD4heQm0HfB6IpymdvsGM8dv");
Dictionary<string, string> payload = new Dictionary<string, string>();
payload.Add("amount", 3000);
payload.Add("description", "Refund for Order #1111");
Refund refund = debit.Refund(payload);
% endif
