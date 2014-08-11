% if mode == 'definition':
Reversal.Save()
% elif mode == 'request':
using Balanced;
using System.Collections.Generic;

Balanced.Balanced.configure("ak-test-25ZY8HQwZPuQtDecrxb671LilUya5t5G0");

Reversal reversal = Reversal.Fetch("/reversals/RV5Fc1aJCtoFdUKBVdErGJed");
Dictionary<string, string> meta = new Dictionary<string, string>();
meta.Add("refund.reason", "user not happy with product");
meta.Add("user.notes", "very polite on the phone");
meta.Add("user.satisfaction", "6");
reversal.meta = meta;
reversal.description = "update this description";
reversal.Save();
% endif
