% if mode == 'definition':
BankAccount.Query()
% elif mode == 'request':
BankAccount bankAccount = BankAccount.Query();
% endif
