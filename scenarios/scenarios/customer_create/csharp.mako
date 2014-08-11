% if mode == 'definition':
new Customer()
% elif mode == 'request':
using Balanced;
using System.Collections.Generic;

Balanced.Balanced.configure("ak-test-25ZY8HQwZPuQtDecrxb671LilUya5t5G0");

Customer customer = Customer.new();
Dictionary<string, string> address = new Dictionary<string, string>();
address.Add("postal_code", "48120");
          
customer.name = "Henry Ford";
customer.dob_month = "7";
customer.dob_year = "1963";
customer.address = address;
customer.Save();
% endif
