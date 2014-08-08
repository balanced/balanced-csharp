% if mode == 'definition':
Order.Save()
% elif mode == 'request':
using Balanced;
using System.Collections.Generic;

Balanced.Balanced.configure("ak-test-DXIgzoqwN4LsoCabloqy87y42qwm1lXR");

Order order = Order.Fetch("/orders/OR30Lgklpj2bIK0fmqDPJsGl");
Dictionary<string, string> meta = new Dictionary<string, string>();
meta.Add("anykey", "valuegoeshere");
meta.Add("product.id", "1234567890");
order.meta = meta;
order.description = "New description for order";
order.Save();
% endif
