% if mode == 'definition':
BankAccount.AssociateToCustomer()
% elif mode == 'request':
using Balanced;

Balanced.Balanced.configure("ak-test-1xLFE6RLC1W3P4ePiQDI4UVpRwtKcdfqL");

BankAccount bankAccount = BankAccount.Fetch("/bank_accounts/BA6g0aWJb8TNd7sXXs17t0Q0");
bankAccount.AssociateToCustomer("/customers/CU4CZc7Xjn8gGJXl1LyzZk7S");
% endif
