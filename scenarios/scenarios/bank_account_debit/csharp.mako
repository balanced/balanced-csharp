% if mode == 'definition':
BankAccount.Debit()
% elif mode == 'request':
BankAcount bankAccount = BankAccount.Fetch( "/bank_accounts/BA15JObs4S8e5Pwd3WsbzBa1" );
Dictionary<string, object> payload = new Dictionary<string, object>();
payload.Add("amount", 5000 );
Debit debit = bankAccount.Debit(payload);
% endif
