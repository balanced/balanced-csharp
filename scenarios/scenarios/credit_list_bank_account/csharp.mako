% if mode == 'definition':
BankAccount.credits
% elif mode == 'request':
BankAccount bankAccount = BankAccount.Fetch("/bank_accounts/BA1iWjnIUhEkl5bORJGRGd9T");
List<Credit> credits = bankAccount.credits;
% endif
