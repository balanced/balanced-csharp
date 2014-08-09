using Balanced;
using System.Collections.Generic;

Balanced.Balanced.configure("{{ api_key }}");

BankAccount bankAccount = BankAccount.Fetch("{{ bank_account_href }}");
Dictionary<string, object> creditPayload = new Dictionary<string, object>();
creditPayload.Add("amount", {{payload.amount }} );
Credit credit = bankAccount.Credit(creditPayload);