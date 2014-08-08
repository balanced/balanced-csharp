% if mode == 'definition':
Debit.Save()
% elif mode == 'request':
using Balanced;
using System.Collections.Generic;

Balanced.Balanced.configure("ak-test-DXIgzoqwN4LsoCabloqy87y42qwm1lXR");

Debit debit = Debit.Fetch("/debits/WD1YcD3F2RbUq8VNpk0YR6U5");
Dictionary<string, string> meta = new Dictionary<string, string>();
meta.Add("anykey", "valuegoeshere");
debit.meta = meta;
debit.description = "New description for debit";
debit.Save();
% endif
