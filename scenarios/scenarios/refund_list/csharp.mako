% if mode == 'definition':
Refund.Query()
% elif mode == 'request':
using Balanced;

Balanced.Balanced.configure("ak-test-DXIgzoqwN4LsoCabloqy87y42qwm1lXR");

List<Refund> refunds = Refund.Query().All();
% endif
