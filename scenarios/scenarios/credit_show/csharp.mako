% if mode == 'definition':
Credit.Fetch()
% elif mode == 'request':
Credit credit = Credit.Fetch("/credits/CR24CQpLWeFxPm96UnVOMB5f");
% endif
