% if mode == 'definition':
Customer.Query()
% elif mode == 'request':
List<Customer> customers = Customer.Query().All();
% endif
