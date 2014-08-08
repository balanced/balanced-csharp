BankAccount bankAccount = BankAccount.Fetch("{{ bank_account_href }}");
Dictionary<string, object> payload = new Dictionary<string, object>();
payload.Add("amount", {{payload.amount}});
payload.Add("appears_on_statement_as", "{{payload.appears_on_statement_as}}");
payload.Add("description", "{{payload.description}}");
Debit debit = bankAccount.Debit(payload);