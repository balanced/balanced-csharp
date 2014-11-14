% if mode == 'definition':
Order.DebitFrom()
% elif mode == 'request':
using Balanced;
using System.Collections.Generic;

Balanced.Balanced.configure("ak-test-DXIgzoqwN4LsoCabloqy87y42qwm1lXR");

Order order = Order.Fetch("/orders/OR26ekFGTu5M22gr9fIKOMhH");
Card card = Card.Fetch("/cards/CC1VmEgD058TlNlPbcGiCac5");
Dictionary<string, object> debitPayload = new Dictionary<string, object>();
debitPayload.Add("amount", 5000);
Debit debit = order.DebitFrom(card, debitPayload);
% endif