% if mode == 'definition':
ApiKey.Unstore()
% elif mode == 'request':
using Balanced;

Balanced.Balanced.configure("ak-test-1xLFE6RLC1W3P4ePiQDI4UVpRwtKcdfqL");

ApiKey key = ApiKey.Fetch("/api_keys/AK5GPcrSGuD1jtq6cEctwa3j");
key.Unstore();
% endif
