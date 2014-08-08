% if mode == 'definition':
Debit.Query()
% elif mode == 'request':
List<Debit> debits = Debit.Query().All();
% endif
