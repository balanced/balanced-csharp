% if mode == 'definition':
CardHold.Query()
% elif mode == 'request':
CardHold cardHolds = CardHold.Query();
% endif
