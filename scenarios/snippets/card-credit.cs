// card_href is the stored href for the Card
// order_href is the stored href for the Order
Card card = Card.Fetch(card_href);
Dictionary<string, object> creditPayload = new Dictionary<string, object>();
creditPayload.Add("amount", 5000);
creditPayload.Add("description", "Some descriptive text for the debit in the dashboard");
creditPayload.Add("order", order_href);
Credit credit = card.Credit(creditPayload);