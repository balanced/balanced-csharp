% if mode == 'definition':
CardHold.Capture()
% elif mode == 'request':
using Balanced;
using System.Collections.Generic;

Balanced.Balanced.configure("ak-test-1xLFE6RLC1W3P4ePiQDI4UVpRwtKcdfqL");

CardHold cardHold = CardHold.fetch("/card_holds/HL44qbPoom3uVlTlEGBZV7z2");
Dictionary<string, object> debitPayload = new Dictionary<string, object>();
debitPayload.Add("appears_on_statement_as", "ShowsUpOnStmt");
debitPayload.Add("description", "Some descriptive text for the debit in the dashboard");
Debit debit = cardHold.Capture(debitPayload);
% endif
