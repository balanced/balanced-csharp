% if mode == 'definition':
BankAccount.Credit()
% elif mode == 'request':
BankAcount bankAccount = BankAccount.Fetch("/bank_accounts/BA1rgE1dqOFhqRaZydCenoBr");
Dictionary<string, object> creditPayload = new Dictionary<string, object>();
creditPayload.Add("amount", 5000 );
Credit credit = bankAccount.Credit(creditPayload);
% endif
