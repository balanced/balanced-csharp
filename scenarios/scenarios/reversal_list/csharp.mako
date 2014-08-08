% if mode == 'definition':
Reversal.Query()
% elif mode == 'request':
using Balanced;

Balanced.Balanced.configure("ak-test-DXIgzoqwN4LsoCabloqy87y42qwm1lXR");

List<Reversal> reversals = Reversal.Query().All();
% endif
