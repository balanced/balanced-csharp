% if mode == 'definition':
Debit.Save()
% elif mode == 'request':
using Balanced;
using System.Collections.Generic;

Balanced.Balanced.configure("ak-test-1xLFE6RLC1W3P4ePiQDI4UVpRwtKcdfqL");

Debit debit = Debit.Fetch("/debits/WD4LT3ghEgoGK9z4wUQCsKUU");
Dictionary<string, string> meta = new Dictionary<string, string>();
meta.Add("anykey", "valuegoeshere");
debit.meta = meta;
debit.description = "New description for debit";
debit.Save();
% endif
