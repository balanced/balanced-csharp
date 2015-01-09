% if mode == 'definition':
Refund.Save()
% elif mode == 'request':
using Balanced;
using System.Collections.Generic;

Balanced.Balanced.configure("ak-test-1xLFE6RLC1W3P4ePiQDI4UVpRwtKcdfqL");

Refund refund = Refund.Fetch("/refunds/RF4zwAHHq8ifpN3M1RLEwSJD");
Dictionary<string, string> meta = new Dictionary<string, string>();
meta.Add("refund.reason", "user not happy with product");
meta.Add("user.notes", "very polite on the phone");
meta.Add("user.refund.count", "3");
refund.meta = meta;
refund.description = "update this description";
refund.Save();
% endif
