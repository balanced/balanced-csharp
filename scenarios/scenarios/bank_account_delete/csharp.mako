% if mode == 'definition':
BankAccount.Unstore()
% elif mode == 'request':
using Balanced;

Balanced.Balanced.configure("ak-test-25ZY8HQwZPuQtDecrxb671LilUya5t5G0");

BankAccount bankAccount = BankAccount.Fetch("/bank_accounts/BA1D19WqGc3j78IAhFIkasQd");
bankAccount.Unstore();
% endif
