% if mode == 'definition':
Card.Query()
% elif mode == 'request':
List<Card> cards = Card.Query().All();
% endif
