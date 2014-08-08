% if mode == 'definition':
Debit.Fetch()
% elif mode == 'request':
using Balanced;

Balanced.Balanced.configure("ak-test-DXIgzoqwN4LsoCabloqy87y42qwm1lXR");

Debit debit = Debit.Fetch("/debits/WD1YcD3F2RbUq8VNpk0YR6U5");
% endif
