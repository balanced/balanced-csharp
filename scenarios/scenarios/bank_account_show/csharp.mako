% if mode == 'definition':
BankAccount.Fetch()
% elif mode == 'request':
BankAcount bankAccount = BankAccount.Fetch("/bank_accounts/BA1iWjnIUhEkl5bORJGRGd9T");
% endif
