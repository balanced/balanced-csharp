% if mode == 'definition':
BankAccount.Verify()
% elif mode == 'request':
using Balanced;

Balanced.Balanced.configure("ak-test-DXIgzoqwN4LsoCabloqy87y42qwm1lXR");

BankAccount bankAccount = BankAccount.Fetch("/bank_accounts/BA15JObs4S8e5Pwd3WsbzBa1");
BankAccountVerification verification = bankAccount.Verify();
% endif
