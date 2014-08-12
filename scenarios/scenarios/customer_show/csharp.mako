% if mode == 'definition':
Customer.Fetch()
% elif mode == 'request':
using Balanced;

Balanced.Balanced.configure("ak-test-DXIgzoqwN4LsoCabloqy87y42qwm1lXR");

Customer customer = Customer.Fetch("/customers/CU2gFeDlunMW6dccQbDZBP3T");
% endif
