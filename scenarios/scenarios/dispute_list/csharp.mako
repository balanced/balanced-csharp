% if mode == 'definition':
Dispute.Query()
% elif mode == 'request':
Dispute disputes = Dispute.Query();
% endif
