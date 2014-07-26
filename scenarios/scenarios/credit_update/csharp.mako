% if mode == 'definition':
Credit.Save()
% elif mode == 'request':
Credit credit = Credit.Fetch("/credits/CR24CQpLWeFxPm96UnVOMB5f");
Dictionary<string, string> meta = new Dictionary<string, string>();
meta.Add("facebook.id", "1234567890");
meta.Add("anykey", "valuegoeshere");
credit.meta = meta;
credit.Save();

% endif
