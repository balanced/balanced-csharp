% if mode == 'definition':
Dispute.Query()
% elif mode == 'request':
using Balanced;

Balanced.Balanced.configure("ak-test-DXIgzoqwN4LsoCabloqy87y42qwm1lXR");

List<Dispute> disputes = Dispute.Query().All();
% endif
