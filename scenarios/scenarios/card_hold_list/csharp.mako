% if mode == 'definition':
CardHold.Query()
% elif mode == 'request':
List<CardHold> cardHolds = CardHold.Query().All();
% endif
