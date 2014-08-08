% if mode == 'definition':
Credit.Query()
% elif mode == 'request':
List<Credit> credits = Credit.Query().All();
% endif
