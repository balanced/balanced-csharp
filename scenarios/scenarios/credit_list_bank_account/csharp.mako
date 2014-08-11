% if mode == 'definition':
BankAccount.credits
% elif mode == 'request':
using Balanced;
using System.Collections.Generic;

Balanced.Balanced.configure("ak-test-25ZY8HQwZPuQtDecrxb671LilUya5t5G0");

BankAccount bankAccount = BankAccount.Fetch("/bank_accounts/BA1D19WqGc3j78IAhFIkasQd");
List<Credit> credits = bankAccount.credits;
% endif
