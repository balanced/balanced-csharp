using Balanced;
using System.Collections.Generic;

Balanced.Balanced.configure("{{ api_key }}");

Order order = Order.Fetch("{{ order_href }}");
Card card = Card.Fetch("{{ card_href }}");
Dictionary<string, object> creditPayload = new Dictionary<string, object>();
creditPayload.Add("amount", {{payload.amount}});
Credit credit = order.CreditTo(card, creditPayload);
