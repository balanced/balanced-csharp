% if mode == 'definition':
Order.Save()
% elif mode == 'request':
using Balanced;
using System.Collections.Generic;

Balanced.Balanced.configure("ak-test-25ZY8HQwZPuQtDecrxb671LilUya5t5G0");

Order order = Order.Fetch("/orders/OR5sl2RJVnbwEf45nq5eATdz");
Dictionary<string, string> meta = new Dictionary<string, string>();
meta.Add("anykey", "valuegoeshere");
meta.Add("product.id", "1234567890");
order.meta = meta;
order.description = "New description for order";
order.Save();
% endif
