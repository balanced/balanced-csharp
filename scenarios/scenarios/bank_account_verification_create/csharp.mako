% if mode == 'definition':
BankAccount.Verify()
% elif mode == 'request':
using Balanced;

Balanced.Balanced.configure("ak-test-1xLFE6RLC1W3P4ePiQDI4UVpRwtKcdfqL");

BankAccount bankAccount = BankAccount.Fetch("/bank_accounts/BA3uzbngfVXy1SGg25Et7iKY");
BankAccountVerification verification = bankAccount.Verify();
% endif
