% if mode == 'definition':
Credit.Fetch()
% elif mode == 'request':
using Balanced;

Balanced.Balanced.configure("ak-test-25ZY8HQwZPuQtDecrxb671LilUya5t5G0");

Credit credit = Credit.Fetch("/credits/CR3yvp1R6162kK7MozoHmSkg");
% endif
