% if mode == 'definition':
Debit.Query()
% elif mode == 'request':
Debit debits = Debit.Query();
% endif
