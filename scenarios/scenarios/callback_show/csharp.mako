% if mode == 'definition':
Callback.Fetch()
% elif mode == 'request':
using Balanced;

Balanced.Balanced.configure("ak-test-DXIgzoqwN4LsoCabloqy87y42qwm1lXR");

Callback callback = Callback.Fetch("/callbacks/CB1vrfo2iNNen2ApNaVuPqzX");
% endif
