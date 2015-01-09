% if mode == 'definition':
BankAccount.Credit()
% elif mode == 'request':
using Balanced;
using System.Collections.Generic;

Balanced.Balanced.configure("ak-test-1xLFE6RLC1W3P4ePiQDI4UVpRwtKcdfqL");

BankAccount bankAccount = BankAccount.Fetch("/bank_accounts/BA6g0aWJb8TNd7sXXs17t0Q0");
Dictionary<string, object> creditPayload = new Dictionary<string, object>();
creditPayload.Add("amount", 5000 );
Credit credit = bankAccount.Credit(creditPayload);
% endif
