card% if mode == 'definition':
Order.CreditTo()
% elif mode == 'request':
using Balanced;
using System.Collections.Generic;

Balanced.Balanced.configure("ak-test-25ZY8HQwZPuQtDecrxb671LilUya5t5G0");

Order order = Order.Fetch("/orders/OR2UWXCNY2nKlqIQhQhWN3Jm");
Card card = Card.Fetch("/cards/CC3IBNr3erYpVuuZDyWNFfet");
Dictionary<string, object> debitPayload = new Dictionary<string, object>();
debitPayload.Add("amount", 5000);
Debit debit = order.CreditTo(card, debitPayload);
% endif
