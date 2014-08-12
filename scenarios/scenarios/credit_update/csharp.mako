% if mode == 'definition':
Credit.Save()
% elif mode == 'request':
using Balanced;
using System.Collections.Generic;

Balanced.Balanced.configure("ak-test-DXIgzoqwN4LsoCabloqy87y42qwm1lXR");

Credit credit = Credit.Fetch("/credits/CR24CQpLWeFxPm96UnVOMB5f");
Dictionary<string, string> meta = new Dictionary<string, string>();
meta.Add("facebook.id", "1234567890");
meta.Add("anykey", "valuegoeshere");
credit.meta = meta;
credit.Save();

% endif
