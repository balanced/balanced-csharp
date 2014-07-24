BankAcount bankAccount = BankAccount.Fetch( "{{ bank_account_href }}" );
Dictionary<string, object> payload = new Dictionary<string, object>();
payload.Add("amount", {{payload.amount}} );
Debit debit = bankAccount.Debit(payload);