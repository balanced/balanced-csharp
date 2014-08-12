% if mode == 'definition':
CardHold.Unstore()
% elif mode == 'request':
using Balanced;

Balanced.Balanced.configure("ak-test-DXIgzoqwN4LsoCabloqy87y42qwm1lXR");

CardHold cardHold = CardHold.fetch("/card_holds/HL1JMRZor2qJCFfmoFuC85PT");
cardHold.Unstore();
% endif
