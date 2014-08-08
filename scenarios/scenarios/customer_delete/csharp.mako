% if mode == 'definition':
Customer.Unstore()
% elif mode == 'request':
using Balanced;

Balanced.Balanced.configure("ak-test-DXIgzoqwN4LsoCabloqy87y42qwm1lXR");

Customer customer = Customer.Fetch("/customers/CU2oHVpN6d0SOEVP1dx6GmlD");
customer.Unstore();
% endif
