% if mode == 'definition':
Order.Fetch()
% elif mode == 'request':
using Balanced;

Balanced.Balanced.configure("ak-test-1xLFE6RLC1W3P4ePiQDI4UVpRwtKcdfqL");

Order order = Order.Fetch("/orders/OR57cG7I7627Xl7Mh3OrVNn7");
% endif
