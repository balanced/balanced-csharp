% if mode == 'definition':
ApiKey.Unstore()
% elif mode == 'request':
using Balanced;

Balanced.Balanced.configure("ak-test-25ZY8HQwZPuQtDecrxb671LilUya5t5G0");

ApiKey key = ApiKey.Fetch("/api_keys/AKJnLWedoBhUHpdhoGEOPew");
key.Unstore();
% endif
