% if mode == 'definition':
Customer.Unstore()
% elif mode == 'request':
using Balanced;

Balanced.Balanced.configure("ak-test-25ZY8HQwZPuQtDecrxb671LilUya5t5G0");

Customer customer = Customer.Fetch("/customers/CU40AyvBB6ny9u3oelCwyc3C");
customer.Unstore();
% endif
