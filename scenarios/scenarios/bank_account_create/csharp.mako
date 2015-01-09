% if mode == 'definition':
new BankAccount()
% elif mode == 'request':
using Balanced;

Balanced.Balanced.configure("ak-test-1xLFE6RLC1W3P4ePiQDI4UVpRwtKcdfqL");

BankAccount bankAccount = BankAccount.new();
bankAccount.account_number = "9900000001";
bankAccount.routing_number = "121000358";
bankAccount.account_type = "checking";
bankAccount.name = "Johann Bernoulli";
bankAccount.save();
% endif
