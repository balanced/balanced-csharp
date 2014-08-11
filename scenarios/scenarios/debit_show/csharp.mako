% if mode == 'definition':
Debit.Fetch()
% elif mode == 'request':
using Balanced;

Balanced.Balanced.configure("ak-test-25ZY8HQwZPuQtDecrxb671LilUya5t5G0");

Debit debit = Debit.Fetch("/debits/WD3nVmuDYvCWCox0YECGc6b3");
% endif
