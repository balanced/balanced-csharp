% if mode == 'definition':
BankAccount.AssociateToCustomer()
% elif mode == 'request':
using Balanced;

Balanced.Balanced.configure("ak-test-25ZY8HQwZPuQtDecrxb671LilUya5t5G0");

BankAccount bankAccount = BankAccount.Fetch("/bank_accounts/BA2gul8YMjFWnFk0fFHXwX6g");
bankAccount.AssociateToCustomer("/customers/CU2718cI8PkMdFyPjboZLZfn");
% endif
