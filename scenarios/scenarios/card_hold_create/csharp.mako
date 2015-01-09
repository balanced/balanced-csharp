% if mode == 'definition':
Card.Hold()
% elif mode == 'request':
using Balanced;
using System.Collections.Generic;

Balanced.Balanced.configure("ak-test-1xLFE6RLC1W3P4ePiQDI4UVpRwtKcdfqL");

Card card = Card.Fetch("/cards/CC48j1De9eVYELLivrgDeCM8");
Dictionary<string, object> holdPayload = new Dictionary<string, object>();
holdPayload.Add("amount", 5000);
holdPayload.Add("description", "Some descriptive text for the debit in the dashboard");
CardHold cardHold = card.Hold(holdPayload);
cardHold.Save();
% endif
