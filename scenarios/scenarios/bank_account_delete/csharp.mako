% if mode == 'definition':
BankAccount.Unstore()
% elif mode == 'request':
BankAccount bankAccount = BankAccount.Fetch("/bank_accounts/BA1iWjnIUhEkl5bORJGRGd9T");
bankAccount.Unstore();
% endif
