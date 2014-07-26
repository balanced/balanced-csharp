% if mode == 'definition':
Customer.Unstore()
% elif mode == 'request':
Customer customer = Customer.Unstore();
% endif
