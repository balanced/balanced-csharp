% if mode == 'definition':
Event.Fetch()
% elif mode == 'request':
Event event = Event.Fetch("/events/EV1e70bdf0fe5211e39d2e061e5f402045");
% endif
