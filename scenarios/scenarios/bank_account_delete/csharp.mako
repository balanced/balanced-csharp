% if mode == 'definition':
BankAccount.Unstore()
% elif mode == 'request':
using Balanced;

Balanced.Balanced.configure("ak-test-1xLFE6RLC1W3P4ePiQDI4UVpRwtKcdfqL");

BankAccount bankAccount = BankAccount.Fetch("/bank_accounts/BA65yqzcgV6DIdGkEpk7fI8E");
bankAccount.Unstore();
% endif
