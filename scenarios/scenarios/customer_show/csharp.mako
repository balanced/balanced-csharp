% if mode == 'definition':
Customer.Fetch()
% elif mode == 'request':
using Balanced;

Balanced.Balanced.configure("ak-test-25ZY8HQwZPuQtDecrxb671LilUya5t5G0");

Customer customer = Customer.Fetch("/customers/CU3SSJgvA5Z69kt05MusbPeE");
% endif
