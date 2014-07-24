% if mode == 'definition':
ApiKey.Query()
% elif mode == 'request':
ApiKey keys = ApiKey.Query()
% endif
