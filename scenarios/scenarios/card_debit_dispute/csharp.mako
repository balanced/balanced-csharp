% if mode == 'definition':
Card.Debit()
% elif mode == 'request':
using Balanced;
using System.Collections.Generic;

Balanced.Balanced.configure("ak-test-25ZY8HQwZPuQtDecrxb671LilUya5t5G0");

Card card = Card.Fetch("/cards/CC4wj9Lfvka6iodY7jzyqSHe");
Dictionary<string, object> debitPayload = new Dictionary<string, object>();
debitPayload.Add("amount", 5000);
debitPayload.Add("description", "Some descriptive text for the debit in the dashboard");
debitPayload.Add("appears_on_statement_as", "Statement text");
Debit debit = card.Debit(debitPayload);
% endif
