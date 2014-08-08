% if mode == 'definition':
Order.Fetch()
% elif mode == 'request':
using Balanced;

Balanced.Balanced.configure("ak-test-DXIgzoqwN4LsoCabloqy87y42qwm1lXR");

Order order = Order.Fetch("/orders/OR30Lgklpj2bIK0fmqDPJsGl");
% endif
