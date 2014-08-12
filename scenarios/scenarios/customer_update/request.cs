using Balanced;
using System.Collections.Generic;

Balanced.Balanced.configure("ak-test-DXIgzoqwN4LsoCabloqy87y42qwm1lXR");

Customer customer = Customer.Fetch("{{ uri }}");
Dictionary<string, string> meta = new Dictionary<string, string>();
meta.Add("shipping-preference", "{{ payload.meta["shipping-preference"] }}");
customer.meta = meta;
customer.email = "{{payload.email}}";
customer.Save();