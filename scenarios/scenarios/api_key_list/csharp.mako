% if mode == 'definition':
ApiKey.Query()
% elif mode == 'request':
List<ApiKey> keys = ApiKey.Query().All();
% endif
