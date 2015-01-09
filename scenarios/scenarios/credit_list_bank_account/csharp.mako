% if mode == 'definition':
BankAccount.credits
% elif mode == 'request':
using Balanced;
using System.Collections.Generic;

Balanced.Balanced.configure("ak-test-1xLFE6RLC1W3P4ePiQDI4UVpRwtKcdfqL");

BankAccount bankAccount = BankAccount.Fetch("/bank_accounts/BA3uzbngfVXy1SGg25Et7iKY");
List<Credit> credits = bankAccount.credits;
% endif
