% if mode == 'definition':
Card.Query()
% elif mode == 'request':
Card cards = Card.Query();
% endif
