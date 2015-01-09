% if mode == 'definition':
Credit.Save()
% elif mode == 'request':
using Balanced;
using System.Collections.Generic;

Balanced.Balanced.configure("ak-test-1xLFE6RLC1W3P4ePiQDI4UVpRwtKcdfqL");

Credit credit = Credit.Fetch("/credits/CR5pb9ux8RYVNTwcJ3jdVF84");
Dictionary<string, string> meta = new Dictionary<string, string>();
meta.Add("facebook.id", "1234567890");
meta.Add("anykey", "valuegoeshere");
credit.meta = meta;
credit.Save();

% endif
