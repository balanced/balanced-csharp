% if mode == 'definition':
Order.Query()
% elif mode == 'request':
Order orders = Order.Query();
% endif
