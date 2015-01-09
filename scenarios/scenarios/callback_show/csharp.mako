% if mode == 'definition':
Callback.Fetch()
% elif mode == 'request':
using Balanced;

Balanced.Balanced.configure("ak-test-1xLFE6RLC1W3P4ePiQDI4UVpRwtKcdfqL");

Callback callback = Callback.Fetch("/callbacks/CB2AtfpEvqtqX33050qgLBtu");
% endif
