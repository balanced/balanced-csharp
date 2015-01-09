using Balanced;
using System.Collections.Generic;

Balanced.Balanced.configure("{{ api_key }}");

Account account = Account.Fetch("{{ href }}");

Dictionary<string, object> creditPayload = new Dictionary<string, object>();
creditPayload.Add("amount", {{payload.amount }} );
creditPayload.Add("appears_on_statement_as", "{{payload.appears_on_statement_as }}" );
creditPayload.Add("description", "{{payload.description }}" );
creditPayload.Add("order", "{{payload.order }}" );
Credit credit = account.Credit(creditPayload);