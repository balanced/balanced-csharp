% if mode == 'definition':
Debit.dispute
% elif mode == 'request':
using Balanced;

Balanced.Balanced.configure("ak-test-25ZY8HQwZPuQtDecrxb671LilUya5t5G0");

Debit debit = Debit.Fetch("/debits/WD4xfFIxpeQpeRHm55Qc2xV3");
dispute = debit.dispute;
% endif
