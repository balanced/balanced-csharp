% if mode == 'definition':
Event.Query()
% elif mode == 'request':
Event events = Event.Query();
% endif
