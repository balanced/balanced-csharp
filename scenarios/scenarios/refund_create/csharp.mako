% if mode == 'definition':
Debit.Refund()
% elif mode == 'request':
using Balanced;
using System.Collections.Generic;

Balanced.Balanced.configure("ak-test-1xLFE6RLC1W3P4ePiQDI4UVpRwtKcdfqL");

Debit debit = Debit.Fetch("/debits/WD4wXVn2sS8lXuKATwXOf7Uc");
Dictionary<string, string> payload = new Dictionary<string, string>();
payload.Add("amount", 3000);
payload.Add("description", "Refund for Order #1111");
Refund refund = debit.Refund(payload);
% endif
