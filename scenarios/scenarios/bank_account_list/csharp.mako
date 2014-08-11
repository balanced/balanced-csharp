% if mode == 'definition':
BankAccount.Query()
% elif mode == 'request':
using Balanced;
using System.Collections.Generic;

Balanced.Balanced.configure("ak-test-25ZY8HQwZPuQtDecrxb671LilUya5t5G0");

List<BankAccount> bankAccounts = BankAccount.Query().All();
% endif
