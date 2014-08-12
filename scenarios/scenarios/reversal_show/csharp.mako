% if mode == 'definition':
Reversal.Fetch()
% elif mode == 'request':
using Balanced;

Balanced.Balanced.configure("ak-test-DXIgzoqwN4LsoCabloqy87y42qwm1lXR");


Reversal reversal = Reversal.Fetch("/reversals/RV3ebCCE94OFi4Wlj8m72rr3");
% endif
