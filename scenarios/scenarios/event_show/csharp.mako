% if mode == 'definition':
Event.Fetch()
% elif mode == 'request':
using Balanced;
using System.Collections.Generic;

Balanced.Balanced.configure("ak-test-1xLFE6RLC1W3P4ePiQDI4UVpRwtKcdfqL");

Event event = Event.Fetch("/events/EV96e2da0887f411e4a02d020fe4ae3568");
% endif
