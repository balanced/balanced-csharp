using Balanced;
using System.Collections.Generic;

Balanced.Balanced.configure("ak-test-DXIgzoqwN4LsoCabloqy87y42qwm1lXR");

BankAccount bankAccount = BankAccount.Fetch("{{ bank_account_href }}");
Dictionary<string, object> creditPayload = new Dictionary<string, object>();
creditPayload.Add("amount", {{payload.amount }} );
Credit credit = bankAccount.Credit(creditPayload);