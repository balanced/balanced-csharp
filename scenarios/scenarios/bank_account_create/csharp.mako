% if mode == 'definition':
new BankAccount()
% elif mode == 'request':
using Balanced;

Balanced.Balanced.configure("ak-test-DXIgzoqwN4LsoCabloqy87y42qwm1lXR");

BankAccount bankAccount = BankAccount.new();
bankAccount.account_number = "9900000001";
bankAccount.routing_number = "121000358";
bankAccount.account_type = "checking";
bankAccount.name = "Johann Bernoulli";
bankAccount.save();
% endif
