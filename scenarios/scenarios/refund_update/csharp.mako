% if mode == 'definition':
Refund.Save()
% elif mode == 'request':
using Balanced;
using System.Collections.Generic;

Balanced.Balanced.configure("ak-test-25ZY8HQwZPuQtDecrxb671LilUya5t5G0");

Refund refund = Refund.Fetch("/refunds/RF4n5AfJ8MRB55oTzVWTRoVa");
Dictionary<string, string> meta = new Dictionary<string, string>();
meta.Add("refund.reason", "user not happy with product");
meta.Add("user.notes", "very polite on the phone");
meta.Add("user.refund.count", "3");
refund.meta = meta;
refund.description = "update this description";
refund.Save();
% endif
