% if mode == 'definition':
BankAccount.Verify()
% elif mode == 'request':
BankAccount bankAccount = BankAccount.Fetch("/bank_accounts/BA15JObs4S8e5Pwd3WsbzBa1");
BankAccountVerification verification = bankAccount.Verify();
bankAccount.Reload();
% endif
