% if mode == 'definition':
Event.Query()
% elif mode == 'request':
List<Event> events = Event.Query().All();
% endif
