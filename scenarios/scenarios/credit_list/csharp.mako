% if mode == 'definition':
Credit.Query()
% elif mode == 'request':
Credit credits = Credit.Query();
% endif
