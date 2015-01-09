% if mode == 'definition':
Settlement.accounts
% elif mode == 'request':
using Balanced;
using System.Collections.Generic;

Balanced.Balanced.configure("ak-test-1xLFE6RLC1W3P4ePiQDI4UVpRwtKcdfqL");

Account account = Account.Fetch("/accounts/AT2E6Ju62P9AnTJwe0fL5kOI");
List<Settlement> settlements = accounts.settlements;
% endif
