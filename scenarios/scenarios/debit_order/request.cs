using Balanced;
using System.Collections.Generic;

Balanced.Balanced.configure("ak-test-DXIgzoqwN4LsoCabloqy87y42qwm1lXR");

Order order = Order.Fetch("{{ order_href }}");
Card card = Card.Fetch("{{ card_href }}");
Dictionary<string, object> debitPayload = new Dictionary<string, object>();
debitPayload.Add("amount", {{payload.amount}});
Debit debit = order.DebitFrom(card, debitPayload);