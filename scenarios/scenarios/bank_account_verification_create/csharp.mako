% if mode == 'definition':
BankAccount.Verify()
% elif mode == 'request':
using Balanced;

Balanced.Balanced.configure("ak-test-25ZY8HQwZPuQtDecrxb671LilUya5t5G0");

BankAccount bankAccount = BankAccount.Fetch("/bank_accounts/BA17zYxBNrmg9isvicjz9Ae4");
BankAccountVerification verification = bankAccount.Verify();
% endif
