using Balanced;
using System.Collections.Generic;

Balanced.Balanced.configure("{{ api_key }}");

Order order = Order.Fetch("{{uri}}");
Dictionary<string, string> meta = new Dictionary<string, string>();
meta.Add("anykey", "{{ payload.meta.["anykey"] }}");
meta.Add("product.id", "{{ payload.meta.["product.id"] }}");
order.meta = meta;
order.description = "{{payload.description}}";
order.Save();