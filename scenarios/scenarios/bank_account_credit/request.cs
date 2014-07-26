BankAcount bankAccount = BankAccount.Fetch("{{ bank_account_href }}");
Dictionary<string, object> creditPayload = new Dictionary<string, object>();
creditPayload.Add("amount", {{payload.amount }} );
Credit credit = bankAccount.Credit(creditPayload);