% if mode == 'definition':
Customer.Save()
% elif mode == 'request':
using Balanced;

Balanced.Balanced.configure("ak-test-DXIgzoqwN4LsoCabloqy87y42qwm1lXR");

Customer customer = Customer.Fetch("/customers/CU2gFeDlunMW6dccQbDZBP3T");
Dictionary<string, string> meta = new Dictionary<string, string>();
meta.Add("shipping-preference", "ground");
customer.meta = meta;
customer.email = "email@newdomain.com";
customer.Save();
% endif
