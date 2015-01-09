% if mode == 'definition':
new Callback()
% elif mode == 'request':
using Balanced;

Balanced.Balanced.configure("ak-test-1xLFE6RLC1W3P4ePiQDI4UVpRwtKcdfqL");


Callback callback = new Callback();
callback.url = "http://www.example.com/callback_test";
callback.method = "post";
callback.Save();
% endif
