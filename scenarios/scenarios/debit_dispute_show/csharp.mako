% if mode == 'definition':
Debit.dispute
% elif mode == 'request':
using Balanced;

Balanced.Balanced.configure("ak-test-DXIgzoqwN4LsoCabloqy87y42qwm1lXR");

Debit debit = Debit.Fetch("/debits/WD2CafjTjONDtHAfyMLIrg45");
dispute = debit.dispute;
% endif
