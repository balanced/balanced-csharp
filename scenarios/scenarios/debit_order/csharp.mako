% if mode == 'definition':
Order.DebitFrom()
% elif mode == 'request':
using Balanced;
using System.Collections.Generic;

Balanced.Balanced.configure("ak-test-25ZY8HQwZPuQtDecrxb671LilUya5t5G0");

Order order = Order.Fetch("/orders/OR2UWXCNY2nKlqIQhQhWN3Jm");
Card card = Card.Fetch("/cards/CC33DRVrekWpiHYjxSdVuqWc");
Dictionary<string, object> debitPayload = new Dictionary<string, object>();
debitPayload.Add("amount", 5000);
Debit debit = order.DebitFrom(card, debitPayload);
% endif
