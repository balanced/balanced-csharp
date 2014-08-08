% if mode == 'definition':
Order.Query()
% elif mode == 'request':
List<Order> orders = Order.Query().All();
% endif
