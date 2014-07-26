% if mode == 'definition':
Order.Fetch()
% elif mode == 'request':
Order order = Order.Fetch("/orders/OR30Lgklpj2bIK0fmqDPJsGl");
% endif
