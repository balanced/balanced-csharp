% if mode == 'definition':
Refund.Fetch()
% elif mode == 'request':
Refund refund = Refund.Fetch("/refunds/RF2z02i73wNPFWG4cjrVweO1");
% endif
