% if mode == 'definition':
new BankAccount()
% elif mode == 'request':
BankAcount bankAccount = BankAccount.new();
bankAccount.account_number = ;
bankAccount.routing_number = ;
bankAccount.account_type = ;
bankAccount.name = ;
bankAccount.save()
% endif
