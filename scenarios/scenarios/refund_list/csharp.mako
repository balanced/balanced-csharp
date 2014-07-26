% if mode == 'definition':
Refund.Query()
% elif mode == 'request':
Refund refunds = Refund.Query();
% endif
