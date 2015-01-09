% if mode == 'definition':
CardHold.Save()
% elif mode == 'request':
using Balanced;
using System.Collections.Generic;

Balanced.Balanced.configure("ak-test-1xLFE6RLC1W3P4ePiQDI4UVpRwtKcdfqL");

CardHold cardHold = CardHold.fetch("/card_holds/HL44qbPoom3uVlTlEGBZV7z2");
Dictionary<string, string> meta = new Dictionary<string, string>();
meta.Add("holding.for.user_id", "user1");
meta.Add("meaningful.key", "some.value");
cardHold.meta = meta;
cardHold.Save();
% endif
