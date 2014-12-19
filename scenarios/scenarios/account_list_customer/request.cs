using Balanced;
using System.Collections.Generic;

Balanced.Balanced.configure("{{ api_key }}");

Customer customer = Customer.Fetch("{{ customer_href }}");
List<Account> accounts = customer.accounts;