% if mode == 'definition':
Debit.Fetch()
% elif mode == 'request':
using Balanced;

Balanced.Balanced.configure("ak-test-25ZY8HQwZPuQtDecrxb671LilUya5t5G0");

Dispute dispute = Dispute.Fetch("/disputes/DT5bIvcPoUL541jY893QHQNB");
% endif
