% if mode == 'definition':
Customer.Save()
% elif mode == 'request':
Customer customer = Customer.Fetch("/customers/CU2gFeDlunMW6dccQbDZBP3T");
Dictionary<string, string> meta = new Dictionary<string, string>();
meta.Add("shipping-preference", "ground");
customer.meta = meta;
customer.email = "email@newdomain.com"
customer.Save();
% endif
