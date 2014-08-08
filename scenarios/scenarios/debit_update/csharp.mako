% if mode == 'definition':
Debit.Save()
% elif mode == 'request':
Debit debit = Debit.Fetch("/debits/WD1YcD3F2RbUq8VNpk0YR6U5");
Dictionary<string, string> meta = new Dictionary<string, string>();
meta.Add("anykey", "valuegoeshere");
debit.meta = meta;
debit.description = "New description for debit"
debit.Save();
% endif
