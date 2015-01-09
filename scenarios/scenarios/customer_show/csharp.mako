% if mode == 'definition':
Customer.Fetch()
% elif mode == 'request':
using Balanced;

Balanced.Balanced.configure("ak-test-1xLFE6RLC1W3P4ePiQDI4UVpRwtKcdfqL");

Customer customer = Customer.Fetch("/customers/CU3BDNwUxRmQTDTQQatYGqr3");
% endif
