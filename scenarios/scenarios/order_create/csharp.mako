% if mode == 'definition':
Customer.CreateOrder()
% elif mode == 'request':
using Balanced;
using System.Collections.Generic;

Balanced.Balanced.configure("ak-test-25ZY8HQwZPuQtDecrxb671LilUya5t5G0");

Customer customer = Customer.Fetch("/customers/CU40AyvBB6ny9u3oelCwyc3C");
Dictionary<string, object> orderPayload = new Dictionary<string, object>();
orderPayload.Add("description", "Order #12341234");
Order order = customer.CreateOrder(orderPayload);
% endif
