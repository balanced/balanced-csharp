% if mode == 'definition':
Order.Save()
% elif mode == 'request':
using Balanced;
using System.Collections.Generic;

Balanced.Balanced.configure("ak-test-1xLFE6RLC1W3P4ePiQDI4UVpRwtKcdfqL");

Order order = Order.Fetch("/orders/OR57cG7I7627Xl7Mh3OrVNn7");
Dictionary<string, string> meta = new Dictionary<string, string>();
meta.Add("anykey", "valuegoeshere");
meta.Add("product.id", "1234567890");
order.meta = meta;
order.description = "New description for order";
order.Save();
% endif
