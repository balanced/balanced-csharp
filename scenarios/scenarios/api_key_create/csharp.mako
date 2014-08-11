% if mode == 'definition':
new ApiKey()
% elif mode == 'request':
using Balanced;

Balanced.Balanced.configure("ak-test-25ZY8HQwZPuQtDecrxb671LilUya5t5G0");

ApiKey key = new ApiKey();
key.Save(); 
% endif
