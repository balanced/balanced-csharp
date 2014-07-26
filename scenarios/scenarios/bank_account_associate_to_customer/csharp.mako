% if mode == 'definition':
BankAccount.AssociateToCustomer()
% elif mode == 'request':
BankAcount bankAccount = BankAccount.Fetch("/bank_accounts/BA1rgE1dqOFhqRaZydCenoBr");
bankAccount.AssociateToCustomer("/customers/CU1q8McSAi35Nb3sqPlMemWN");
% endif
