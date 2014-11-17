% if mode == 'definition':
CardHold.Capture()
% elif mode == 'request':
using Balanced;
using System.Collections.Generic;

Balanced.Balanced.configure("ak-test-25ZY8HQwZPuQtDecrxb671LilUya5t5G0");

CardHold cardHold = CardHold.fetch("/card_holds/HL2F8jlnySjVKidwfXgBYZMY");
Dictionary<string, object> debitPayload = new Dictionary<string, object>();
debitPayload.Add("appears_on_statement_as", "ShowsUpOnStmt");
debitPayload.Add("description", "Some descriptive text for the debit in the dashboard");
Debit debit = cardHold.Capture(debitPayload);
% endif
