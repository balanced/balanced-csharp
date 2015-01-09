% if mode == 'definition':
Customer.CreateOrder()
% elif mode == 'request':
using Balanced;
using System.Collections.Generic;

Balanced.Balanced.configure("ak-test-1xLFE6RLC1W3P4ePiQDI4UVpRwtKcdfqL");

Customer customer = Customer.Fetch("/customers/CU3MjqyarSxE66kggE8MMtGB");
Dictionary<string, object> orderPayload = new Dictionary<string, object>();
orderPayload.Add("description", "Order #12341234");
Order order = customer.CreateOrder(orderPayload);
% endif
