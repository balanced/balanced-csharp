% if mode == 'definition':
Customer.Save()
% elif mode == 'request':
using Balanced;
using System.Collections.Generic;

Balanced.Balanced.configure("ak-test-25ZY8HQwZPuQtDecrxb671LilUya5t5G0");

Customer customer = Customer.Fetch("/customers/CU3SSJgvA5Z69kt05MusbPeE");
Dictionary<string, string> meta = new Dictionary<string, string>();
meta.Add("shipping-preference", "ground");
customer.meta = meta;
customer.email = "email@newdomain.com";
customer.Save();
% endif
