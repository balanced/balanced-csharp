% if mode == 'definition':
new Callback()
% elif mode == 'request':
using Balanced;

Balanced.Balanced.configure("ak-test-DXIgzoqwN4LsoCabloqy87y42qwm1lXR");

Callback callback = new Callback();
callback.url = "http://www.example.com/callback";
callback.method = "post";
callback.Save();
% endif
