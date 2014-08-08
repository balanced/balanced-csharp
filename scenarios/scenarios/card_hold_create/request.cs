using Balanced;
using System.Collections.Generic;

Balanced.Balanced.configure("ak-test-DXIgzoqwN4LsoCabloqy87y42qwm1lXR");

Card card = Card.Fetch("{{ card_href }}");
Dictionary<string, object> holdPayload = new Dictionary<string, object>();
holdPayload.Add("amount", {{ payload.amount }});
holdPayload.Add("description", "{{ payload.description }}");
CardHold cardHold = card.Hold(holdPayload);
cardHold.Save();