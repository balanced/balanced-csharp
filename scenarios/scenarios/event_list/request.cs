using Balanced;
using System.Collections.Generic;

Balanced.Balanced.configure("{{ api_key }}");

List<Event> events = Event.Query().All();