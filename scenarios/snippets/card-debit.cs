// card_href is the stored href for the Card
// order_href is the stored href for the Order
Card card = Card.Fetch(card_href);
Dictionary<string, object> debitPayload = new Dictionary<string, object>();
debitPayload.Add("amount", 5000);
debitPayload.Add("description", "Some descriptive text for the debit in the dashboard");
debitPayload.Add("appears_on_statement_as", "Statement text");
debitPayload.Add("order", order_href);
Debit debit = card.Debit(debitPayload);