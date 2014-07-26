% if mode == 'definition':
CardHold.Fetch()
% elif mode == 'request':
CardHold cardHold = CardHold.fetch("/card_holds/HL1CflQId0CQs3t6o53ZIqax");
% endif
