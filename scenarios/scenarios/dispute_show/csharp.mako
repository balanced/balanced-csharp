% if mode == 'definition':
Debit.Fetch()
% elif mode == 'request':
using Balanced;

Balanced.Balanced.configure("ak-test-DXIgzoqwN4LsoCabloqy87y42qwm1lXR");

Dispute dispute = Dispute.Fetch("/disputes/DT2Ofhtver9y9vsv5NvcZ21l");
% endif
