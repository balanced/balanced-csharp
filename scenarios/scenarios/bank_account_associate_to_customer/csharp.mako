% if mode == 'definition':
BankAccount.AssociateToCustomer()
% elif mode == 'request':
using Balanced;

Balanced.Balanced.configure("ak-test-DXIgzoqwN4LsoCabloqy87y42qwm1lXR");

BankAccount bankAccount = BankAccount.Fetch("/bank_accounts/BA1rgE1dqOFhqRaZydCenoBr");
bankAccount.AssociateToCustomer("/customers/CU1q8McSAi35Nb3sqPlMemWN");
% endif
