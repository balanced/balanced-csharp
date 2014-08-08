% if mode == 'definition':
Callback.Query()
% elif mode == 'request':
using Balanced;
using System.Collections.Generic;

Balanced.Balanced.configure("ak-test-DXIgzoqwN4LsoCabloqy87y42qwm1lXR");

List<Callback> callbacks = Callback.Query().All();
% endif
