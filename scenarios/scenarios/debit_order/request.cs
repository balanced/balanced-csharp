Order order = Order.Fetch("{{ order_href }}");
Card card = Card.Fetch("{{ card_href }}");
Dictionary<string, object> debitPayload = new Dictionary<string, object>();
debitPayload.Add("amount", {{payload.amount}});
Debit debit = order.DebitFrom(card, debitPayload);