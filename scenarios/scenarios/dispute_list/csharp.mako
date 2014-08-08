% if mode == 'definition':
Dispute.Query()
% elif mode == 'request':
List<Dispute> disputes = Dispute.Query().All();
% endif
