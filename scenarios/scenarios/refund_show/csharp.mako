% if mode == 'definition':
Refund.Fetch()
% elif mode == 'request':
using Balanced;

Balanced.Balanced.configure("ak-test-DXIgzoqwN4LsoCabloqy87y42qwm1lXR");

Refund refund = Refund.Fetch("/refunds/RF2z02i73wNPFWG4cjrVweO1");
% endif
