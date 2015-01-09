% if mode == 'definition':
Order.Query()
% elif mode == 'request':
using Balanced;
using System.Collections.Generic;

Balanced.Balanced.configure("ak-test-1xLFE6RLC1W3P4ePiQDI4UVpRwtKcdfqL");

List<Order> orders = Order.Query().All();
% endif
