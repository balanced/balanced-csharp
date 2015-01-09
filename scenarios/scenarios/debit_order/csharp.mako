% if mode == 'definition':
Order.DebitFrom()
% elif mode == 'request':
using Balanced;
using System.Collections.Generic;

Balanced.Balanced.configure("ak-test-1xLFE6RLC1W3P4ePiQDI4UVpRwtKcdfqL");

Order order = Order.Fetch("/orders/OR5e6wrps4tp9QarDxWa01O5");
Card card = Card.Fetch("/cards/CC2SHYWrrAN9Vvl3vuznGeHu");
Dictionary<string, object> debitPayload = new Dictionary<string, object>();
debitPayload.Add("amount", 5000);
Debit debit = order.DebitFrom(card, debitPayload);
% endif
