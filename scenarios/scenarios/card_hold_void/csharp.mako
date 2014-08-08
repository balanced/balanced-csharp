% if mode == 'definition':
CardHold.Unstore()
% elif mode == 'request':
CardHold cardHold = CardHold.fetch("/card_holds/HL1JMRZor2qJCFfmoFuC85PT");
cardHold.Unstore();
% endif
