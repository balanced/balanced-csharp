% if mode == 'definition':
CardHold.Fetch()
% elif mode == 'request':
using Balanced;

Balanced.Balanced.configure("ak-test-DXIgzoqwN4LsoCabloqy87y42qwm1lXR");

CardHold cardHold = CardHold.fetch("/card_holds/HL1CflQId0CQs3t6o53ZIqax");
% endif
