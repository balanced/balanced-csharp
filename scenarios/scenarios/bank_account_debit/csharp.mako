% if mode == 'definition':
BankAccount.Debit()
% elif mode == 'request':
BankAcount bankAccount = BankAccount.Fetch( "/bank_accounts/BA15JObs4S8e5Pwd3WsbzBa1" );
Dictionary<string, object> payload = new Dictionary<string, object>();
payload.Add("amount", 5000 );
payload.Add("appears_on_statement_as", "Statement text" );
payload.Add("description", "Some descriptive text for the debit in the dashboard" );
Debit debit = bankAccount.Debit(payload);
% endif
