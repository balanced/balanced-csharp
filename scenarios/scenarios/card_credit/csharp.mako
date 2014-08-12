% if mode == 'definition':
Card.Credit()
% elif mode == 'request':
using Balanced;
using System.Collections.Generic;

Balanced.Balanced.configure("ak-test-DXIgzoqwN4LsoCabloqy87y42qwm1lXR");

Card card = Card.Fetch("/cards/CC228EUcLHBcrAb5SrNEcIUp");
Dictionary<string, object> creditPayload = new Dictionary<string, object>();
creditPayload.Add("amount", 5000);
creditPayload.Add("description", "Some descriptive text for the debit in the dashboard");
Credit credit = card.Credit(creditPayload);
% endif
