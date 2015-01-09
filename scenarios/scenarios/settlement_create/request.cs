using Balanced;
using System.Collections.Generic;

Balanced.Balanced.configure("{{ api_key }}");

Account account = Account.Fetch("{{ href }}");
Dictionary<string, object> settlementPayload = new Dictionary<string, object>();
settlementPayload.Add("funding_instrument", "{{payload.funding_instrument }}" );
settlementPayload.Add("appears_on_statement_as", "{{payload.appears_on_statement_as }}" );
settlementPayload.Add("description", "{{payload.description }}" );
Settlement settlements = account.Settle(settlementPayload);