% if mode == 'definition':
Account.Fetch()
% elif mode == 'request':
using Balanced;

Balanced.Balanced.configure("ak-test-1xLFE6RLC1W3P4ePiQDI4UVpRwtKcdfqL");

Account account = Account.Fetch("/accounts/AT2t2NS6otEMnPT0jVuRAE6Y");
% endif
