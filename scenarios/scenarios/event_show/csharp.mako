% if mode == 'definition':
Event.Fetch()
% elif mode == 'request':
using Balanced;
using System.Collections.Generic;

Balanced.Balanced.configure("ak-test-DXIgzoqwN4LsoCabloqy87y42qwm1lXR");

Event event = Event.Fetch("/events/EV1e70bdf0fe5211e39d2e061e5f402045");
% endif
