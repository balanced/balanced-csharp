% if mode == 'definition':
Customer.Unstore()
% elif mode == 'request':
using Balanced;

Balanced.Balanced.configure("ak-test-1xLFE6RLC1W3P4ePiQDI4UVpRwtKcdfqL");

Customer customer = Customer.Fetch("/customers/CU3MjqyarSxE66kggE8MMtGB");
customer.Unstore();
% endif
