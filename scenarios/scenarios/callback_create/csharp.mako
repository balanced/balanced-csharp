% if mode == 'definition':
new Callback()
% elif mode == 'request':
Callback callback = new Callback();
callback.url = "http://www.example.com/callback";
callback.method = "post";
callback.Save();
% endif
