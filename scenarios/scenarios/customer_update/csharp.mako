% if mode == 'definition':
Customer.Save()
% elif mode == 'request':
using Balanced;
using System.Collections.Generic;

Balanced.Balanced.configure("ak-test-1xLFE6RLC1W3P4ePiQDI4UVpRwtKcdfqL");

Customer customer = Customer.Fetch("/customers/CU3BDNwUxRmQTDTQQatYGqr3");
Dictionary<string, string> meta = new Dictionary<string, string>();
meta.Add("shipping-preference", "ground");
customer.meta = meta;
customer.email = "email@newdomain.com";
customer.Save();
% endif
