% if mode == 'definition':
Account.Settle()
% elif mode == 'request':
using Balanced;
using System.Collections.Generic;

Balanced.Balanced.configure("ak-test-1xLFE6RLC1W3P4ePiQDI4UVpRwtKcdfqL");

Account account = Account.Fetch("/accounts/AT2E6Ju62P9AnTJwe0fL5kOI");
Dictionary<string, object> settlementPayload = new Dictionary<string, object>();
settlementPayload.Add("funding_instrument", "/bank_accounts/BA3uzbngfVXy1SGg25Et7iKY");
settlementPayload.Add("appears_on_statement_as", "ThingsCo");
settlementPayload.Add("description", "Payout A");
Settlement settlements = account.Settle(settlementPayload);
% endif
