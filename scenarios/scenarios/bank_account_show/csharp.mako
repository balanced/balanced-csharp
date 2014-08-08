% if mode == 'definition':
BankAccount.Fetch()
% elif mode == 'request':
using Balanced;

Balanced.Balanced.configure("ak-test-DXIgzoqwN4LsoCabloqy87y42qwm1lXR");

BankAccount bankAccount = BankAccount.Fetch("/bank_accounts/BA1iWjnIUhEkl5bORJGRGd9T");
% endif
