using Balanced;
using System.Collections.Generic;

Balanced.Balanced.configure("{{ api_key }}");

Customer customer = Customer.Fetch("{{customer_href}}");
Dictionary<string, object> orderPayload = new Dictionary<string, object>();
orderPayload.Add("description", "{{payload.description}}");
Order order = customer.CreateOrder(orderPayload);