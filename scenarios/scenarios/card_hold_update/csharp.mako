% if mode == 'definition':
CardHold.Save()
% elif mode == 'request':
using Balanced;
using System.Collections.Generic;

Balanced.Balanced.configure("ak-test-DXIgzoqwN4LsoCabloqy87y42qwm1lXR");

CardHold cardHold = CardHold.fetch("/card_holds/HL1CflQId0CQs3t6o53ZIqax");
Dictionary<string, string> meta = new Dictionary<string, string>();
meta.Add("holding.for.user_id", "user1");
meta.Add("meaningful.key", "some.value");
cardHold.meta = meta;
cardHold.Save();
% endif
