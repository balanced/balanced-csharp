% if mode == 'definition':
Order.Debit()
% elif mode == 'request':
Order order = Order.Fetch("/orders/OR26ekFGTu5M22gr9fIKOMhH");
Card card = Card.Fetch("/cards/CC1VmEgD058TlNlPbcGiCac5");
Dictionary<string, object> debitPayload = new Dictionary<string, object>();
debitPayload.Add("amount", 5000);
Debit debit = order.DebitFrom(card, debitPayload);
% endif
