% if mode == 'definition':
new ApiKey()
% elif mode == 'request':
ApiKey key = new ApiKey();
key.Save();
% endif
