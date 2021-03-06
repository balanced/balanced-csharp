﻿using Balanced;
using System.Collections.Generic;

Balanced.Balanced.configure("{{ api_key }}");

Card card = Card.Fetch("{{ card_href }}");
Dictionary<string, object> debitPayload = new Dictionary<string, object>();
debitPayload.Add("amount", {{ payload.amount }});
debitPayload.Add("description", "{{ payload.description }}");
debitPayload.Add("appears_on_statement_as", "{{ payload.appears_on_statement_as }}");
Debit debit = card.Debit(debitPayload);