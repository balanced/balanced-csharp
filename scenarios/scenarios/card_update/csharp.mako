% if mode == 'definition':
Card.Save()
% elif mode == 'request':
using Balanced;
using System.Collections.Generic;

Balanced.Balanced.configure("ak-test-1xLFE6RLC1W3P4ePiQDI4UVpRwtKcdfqL");

Card card = Card.Fetch("/cards/CC2SHYWrrAN9Vvl3vuznGeHu");
Dictionary<string, string> meta = new Dictionary<string, string>();
meta.Add("facebook.user_id", "0192837465");
meta.Add("my-own-customer-id", "12345");
meta.Add("twitter.id", "1234987650");
card.meta = meta;
card.Save();
% endif
