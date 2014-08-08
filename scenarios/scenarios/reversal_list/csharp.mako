% if mode == 'definition':
Reversal.Query()
% elif mode == 'request':
List<Reversal> reversals = Reversal.Query().All();
% endif
