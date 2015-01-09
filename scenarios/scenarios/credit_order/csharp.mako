% if mode == 'definition':
Order.CreditTo()
% elif mode == 'request':
using Balanced;
using System.Collections.Generic;

Balanced.Balanced.configure("ak-test-1xLFE6RLC1W3P4ePiQDI4UVpRwtKcdfqL");

Order order = Order.Fetch("/orders/OR5e6wrps4tp9QarDxWa01O5");
BankAccount bankAccount = BankAccount.Fetch("/bank_accounts/BA6g0aWJb8TNd7sXXs17t0Q0/credits");
Dictionary<string, object> creditPayload = new Dictionary<string, object>();
creditPayload.Add("amount", 5000);
Credit credit = order.CreditTo(bankAccount, creditPayload);
% endif
