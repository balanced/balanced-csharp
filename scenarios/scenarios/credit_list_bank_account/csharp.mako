% if mode == 'definition':
BankAccount.credits
% elif mode == 'request':
BankAccount bankAccount = BankAccount.Fetch("/bank_accounts/BA1iWjnIUhEkl5bORJGRGd9T");
Credit.Collection credits = bankAccount.credits;
% endif
