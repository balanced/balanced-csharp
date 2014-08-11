% if mode == 'definition':
Card.Credit()
% elif mode == 'request':
using Balanced;
using System.Collections.Generic;

Balanced.Balanced.configure("ak-test-25ZY8HQwZPuQtDecrxb671LilUya5t5G0");

Card card = Card.Fetch("/cards/CC3iCCIHprJu5HPyP7vmE92B");
Dictionary<string, object> creditPayload = new Dictionary<string, object>();
creditPayload.Add("amount", 5000);
creditPayload.Add("description", "Some descriptive text for the debit in the dashboard");
Credit credit = card.Credit(creditPayload);
% endif
