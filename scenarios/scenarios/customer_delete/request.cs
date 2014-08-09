using Balanced;

Balanced.Balanced.configure("{{ api_key }}");

Customer customer = Customer.Fetch("{{uri}}");
customer.Unstore();