% if mode == 'definition':
BankAccount.Query()
% elif mode == 'request':
BankAcount bankAccount = BankAccount.Query();
% endif
