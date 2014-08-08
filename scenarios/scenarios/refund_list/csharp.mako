% if mode == 'definition':
Refund.Query()
% elif mode == 'request':
List<Refund> refunds = Refund.Query().All();
% endif
