% if mode == 'definition':
Refund.Save()
% elif mode == 'request':
Refund refund = Refund.Fetch("/refunds/RF2z02i73wNPFWG4cjrVweO1");
Dictionary<string, string> meta = new Dictionary<string, string>();
meta.Add("refund.reason", "user not happy with product");
meta.Add("user.notes", "very polite on the phone");
meta.Add("user.refund.count", "3");
refund.meta = meta;
refund.description = "update this description";
refund.Save();
% endif
