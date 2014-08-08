using Balanced;
using System.Collections.Generic;

Balanced.Balanced.configure("ak-test-DXIgzoqwN4LsoCabloqy87y42qwm1lXR");

Card card = Card.Fetch("{{ card_href }}");
Dictionary<string, object> creditPayload = new Dictionary<string, object>();
creditPayload.Add("amount", {{ payload.amount }});
creditPayload.Add("description", "{{ payload.description }}");
Credit credit = card.Credit(creditPayload);