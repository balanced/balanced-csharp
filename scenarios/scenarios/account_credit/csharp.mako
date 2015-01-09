% if mode == 'definition':
Account.Credit()
% elif mode == 'request':
using Balanced;
using System.Collections.Generic;

Balanced.Balanced.configure("ak-test-1xLFE6RLC1W3P4ePiQDI4UVpRwtKcdfqL");

Account account = Account.Fetch("/accounts/AT2E6Ju62P9AnTJwe0fL5kOI");

Dictionary<string, object> creditPayload = new Dictionary<string, object>();
creditPayload.Add("amount", 1000);
creditPayload.Add("appears_on_statement_as", "ThingsCo");
creditPayload.Add("description", "A simple credit");
creditPayload.Add("order", "/orders/OR2JfBYxYlDAF3L48u9DtIEU");
Credit credit = account.Credit(creditPayload);
% endif
