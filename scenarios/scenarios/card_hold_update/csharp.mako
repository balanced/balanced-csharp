% if mode == 'definition':
CardHold.Save()
% elif mode == 'request':
using Balanced;
using System.Collections.Generic;

Balanced.Balanced.configure("ak-test-25ZY8HQwZPuQtDecrxb671LilUya5t5G0");

CardHold cardHold = CardHold.fetch("/card_holds/HL2F8jlnySjVKidwfXgBYZMY");
Dictionary<string, string> meta = new Dictionary<string, string>();
meta.Add("holding.for.user_id", "user1");
meta.Add("meaningful.key", "some.value");
cardHold.meta = meta;
cardHold.Save();
% endif
