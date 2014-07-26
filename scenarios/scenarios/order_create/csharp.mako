% if mode == 'definition':
new Order
% elif mode == 'request':
Customer customer = Customer.Fetch("/customers/CU2oHVpN6d0SOEVP1dx6GmlD");
Dictionary<string, object> orderPayload = new Dictionary<string, object>();
orderPayload.Add("description", "Order #12341234");
Order order = customer.createOrder(orderPayload);
% endif
