using Balanced;
using System.Collections.Generic;

Balanced.Balanced.configure("ak-test-DXIgzoqwN4LsoCabloqy87y42qwm1lXR");

CardHold cardHold = CardHold.fetch("{{ card_hold_href }}");
Dictionary<string, object> debitPayload = new Dictionary<string, object>();
debitPayload.Add("appears_on_statement_as", "{{ payload.appears_on_statement_as }}");
debitPayload.Add("description", "{{ payload.description }}");
Debit debit = cardHold.Capture(debitPayload);