% if mode == 'definition':
Callback.Query()
% elif mode == 'request':
List<Callback> callbacks = Callback.Query().All();
% endif
