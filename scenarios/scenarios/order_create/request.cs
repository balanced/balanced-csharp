using Balanced;
using System.Collections.Generic;

Balanced.Balanced.configure("ak-test-DXIgzoqwN4LsoCabloqy87y42qwm1lXR");

Customer customer = Customer.Fetch("{{customer_href}}");
Dictionary<string, object> orderPayload = new Dictionary<string, object>();
orderPayload.Add("description", "{{payload.description}}");
Order order = customer.CreateOrder(orderPayload);