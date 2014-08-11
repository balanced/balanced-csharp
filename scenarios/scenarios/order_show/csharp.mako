% if mode == 'definition':
Order.Fetch()
% elif mode == 'request':
using Balanced;

Balanced.Balanced.configure("ak-test-25ZY8HQwZPuQtDecrxb671LilUya5t5G0");

Order order = Order.Fetch("/orders/OR5sl2RJVnbwEf45nq5eATdz");
% endif
