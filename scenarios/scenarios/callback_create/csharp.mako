% if mode == 'definition':
new Callback()
% elif mode == 'request':
using Balanced;

Balanced.Balanced.configure("ak-test-25ZY8HQwZPuQtDecrxb671LilUya5t5G0");


Callback callback = new Callback();
callback.url = "http://www.example.com/callback";
callback.method = "post";
callback.Save();
% endif
