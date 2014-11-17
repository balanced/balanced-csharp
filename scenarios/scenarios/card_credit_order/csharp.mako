% if mode == 'definition':
Order.CreditTo()
% elif mode == 'request':
using Balanced;
using System.Collections.Generic;

Balanced.Balanced.configure("ak-test-25ZY8HQwZPuQtDecrxb671LilUya5t5G0");

Order order = Order.Fetch("/orders/OR2UWXCNY2nKlqIQhQhWN3Jm");
Card card = Card.Fetch("/cards/CC3IBNr3erYpVuuZDyWNFfet");
Dictionary<string, object> creditPayload = new Dictionary<string, object>();
creditPayload.Add("amount", 5000);
Credit credit = order.CreditTo(card, creditPayload);
% endif
