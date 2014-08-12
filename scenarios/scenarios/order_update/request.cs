using Balanced;
using System.Collections.Generic;

Balanced.Balanced.configure("ak-test-DXIgzoqwN4LsoCabloqy87y42qwm1lXR");

Order order = Order.Fetch("{{uri}}");
Dictionary<string, string> meta = new Dictionary<string, string>();
meta.Add("anykey", "{{ payload.meta.["anykey"] }}");
meta.Add("product.id", "{{ payload.meta.["product.id"] }}");
order.meta = meta;
order.description = "{{payload.description}}";
order.Save();