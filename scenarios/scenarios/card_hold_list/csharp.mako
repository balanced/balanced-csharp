% if mode == 'definition':
CardHold.Query()
% elif mode == 'request':
using Balanced;
using System.Collections.Generic;

Balanced.Balanced.configure("ak-test-DXIgzoqwN4LsoCabloqy87y42qwm1lXR");

List<CardHold> cardHolds = CardHold.Query().All();
% endif
