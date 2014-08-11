% if mode == 'definition':
Debit.Save()
% elif mode == 'request':
using Balanced;
using System.Collections.Generic;

Balanced.Balanced.configure("ak-test-25ZY8HQwZPuQtDecrxb671LilUya5t5G0");

Debit debit = Debit.Fetch("/debits/WD3nVmuDYvCWCox0YECGc6b3");
Dictionary<string, string> meta = new Dictionary<string, string>();
meta.Add("anykey", "valuegoeshere");
debit.meta = meta;
debit.description = "New description for debit";
debit.Save();
% endif
