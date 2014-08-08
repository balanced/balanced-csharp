% if mode == 'definition':
BankAccount.Fetch()
% elif mode == 'request':
BankAccount bankAccount = BankAccount.Fetch("/bank_accounts/BA1iWjnIUhEkl5bORJGRGd9T");
% endif
