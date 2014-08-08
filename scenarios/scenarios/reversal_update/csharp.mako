% if mode == 'definition':
Reversal.Save()
% elif mode == 'request':
using Balanced;

Balanced.Balanced.configure("ak-test-DXIgzoqwN4LsoCabloqy87y42qwm1lXR");

Reversal reversal = Reversal.Fetch("/reversals/RV3ebCCE94OFi4Wlj8m72rr3");
Dictionary<string, string> meta = new Dictionary<string, string>();
meta.Add("refund.reason", "user not happy with product");
meta.Add("user.notes", "very polite on the phone");
meta.Add("user.satisfaction", "6");
reversal.meta = meta;
reversal.description = "update this description";
reversal.Save();
% endif
