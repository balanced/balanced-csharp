% if mode == 'definition':
Refund.Fetch()
% elif mode == 'request':
using Balanced;

Balanced.Balanced.configure("ak-test-25ZY8HQwZPuQtDecrxb671LilUya5t5G0");

Refund refund = Refund.Fetch("/refunds/RF4n5AfJ8MRB55oTzVWTRoVa");
% endif
