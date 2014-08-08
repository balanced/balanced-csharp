% if mode == 'definition':
Credit.Fetch()
% elif mode == 'request':
using Balanced;

Balanced.Balanced.configure("ak-test-DXIgzoqwN4LsoCabloqy87y42qwm1lXR");

Credit credit = Credit.Fetch("/credits/CR24CQpLWeFxPm96UnVOMB5f");
% endif
