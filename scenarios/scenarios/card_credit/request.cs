using Balanced;
using System.Collections.Generic;

Balanced.Balanced.configure("{{ api_key }}");

Card card = Card.Fetch("{{ card_href }}");
Dictionary<string, object> creditPayload = new Dictionary<string, object>();
creditPayload.Add("amount", {{ payload.amount }});
creditPayload.Add("description", "{{ payload.description }}");
Credit credit = card.Credit(creditPayload);