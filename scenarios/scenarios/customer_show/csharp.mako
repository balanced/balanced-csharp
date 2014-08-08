% if mode == 'definition':
Customer.Fetch()
% elif mode == 'request':
Customer customer = Customer.Fetch("/customers/CU2gFeDlunMW6dccQbDZBP3T")
% endif
