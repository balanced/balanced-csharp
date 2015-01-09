% if mode == 'definition':
Callback.Query()
% elif mode == 'request':
using Balanced;
using System.Collections.Generic;

Balanced.Balanced.configure("ak-test-1xLFE6RLC1W3P4ePiQDI4UVpRwtKcdfqL");

List<Callback> callbacks = Callback.Query().All();
% endif
