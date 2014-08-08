% if mode == 'definition':
BankAccount.Query()
% elif mode == 'request':
List<BankAccount> bankAccounts = BankAccount.Query().All();
% endif
