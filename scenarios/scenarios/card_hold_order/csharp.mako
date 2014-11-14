% if mode == 'definition':
Card.Hold()
% elif mode == 'request':
using Balanced;
using System.Collections.Generic;

Balanced.Balanced.configure("ak-test-25ZY8HQwZPuQtDecrxb671LilUya5t5G0");

Card card = Card.Fetch("/cards/CC2E1bHjwNbYtzUcTAmH4kEM");
Dictionary<string, object> holdPayload = new Dictionary<string, object>();
holdPayload.Add("amount", 5000);
holdPayload.Add("description", "Some descriptive text for the debit in the dashboard");
holdPayload.Add("order", "/orders/OR5sl2RJVnbwEf45nq5eATdz");
CardHold cardHold = card.Hold(holdPayload);
cardHold.Save();
% endif
