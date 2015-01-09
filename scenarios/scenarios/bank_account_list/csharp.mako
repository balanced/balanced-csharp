% if mode == 'definition':
BankAccount.Query()
% elif mode == 'request':
using Balanced;
using System.Collections.Generic;

Balanced.Balanced.configure("ak-test-1xLFE6RLC1W3P4ePiQDI4UVpRwtKcdfqL");

List<BankAccount> bankAccounts = BankAccount.Query().All();
% endif
