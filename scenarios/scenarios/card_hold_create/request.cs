using Balanced;
using System.Collections.Generic;

Balanced.Balanced.configure("{{ api_key }}");

Card card = Card.Fetch("{{ card_href }}");
Dictionary<string, object> holdPayload = new Dictionary<string, object>();
holdPayload.Add("amount", {{ payload.amount }});
holdPayload.Add("description", "{{ payload.description }}");
CardHold cardHold = card.Hold(holdPayload);
cardHold.Save();