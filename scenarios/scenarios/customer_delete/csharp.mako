% if mode == 'definition':
Customer.Unstore()
% elif mode == 'request':
Customer customer = Customer.Fetch("/customers/CU2oHVpN6d0SOEVP1dx6GmlD");
customer.Unstore();
% endif
