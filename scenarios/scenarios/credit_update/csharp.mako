% if mode == 'definition':
Credit.Save()
% elif mode == 'request':
using Balanced;
using System.Collections.Generic;

Balanced.Balanced.configure("ak-test-25ZY8HQwZPuQtDecrxb671LilUya5t5G0");

Credit credit = Credit.Fetch("/credits/CR3yvp1R6162kK7MozoHmSkg");
Dictionary<string, string> meta = new Dictionary<string, string>();
meta.Add("facebook.id", "1234567890");
meta.Add("anykey", "valuegoeshere");
credit.meta = meta;
credit.Save();

% endif
