% if mode == 'definition':
new ApiKey()
% elif mode == 'request':
using Balanced;

Balanced.Balanced.configure("ak-test-1xLFE6RLC1W3P4ePiQDI4UVpRwtKcdfqL");

ApiKey key = new ApiKey();
key.Save(); 
% endif
