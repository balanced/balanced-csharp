% if mode == 'definition':
Card.Save()
% elif mode == 'request':
using Balanced;
using System.Collections.Generic;

Balanced.Balanced.configure("ak-test-25ZY8HQwZPuQtDecrxb671LilUya5t5G0");

Card card = Card.Fetch("/cards/CC33DRVrekWpiHYjxSdVuqWc");
Dictionary<string, string> meta = new Dictionary<string, string>();
meta.Add("facebook.user_id", "0192837465");
meta.Add("my-own-customer-id", "12345");
meta.Add("twitter.id", "1234987650");
card.meta = meta;
card.Save();
% endif
