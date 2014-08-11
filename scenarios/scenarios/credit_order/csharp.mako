% if mode == 'definition':
Order.CreditTo()
% elif mode == 'request':
using Balanced;
using System.Collections.Generic;

Balanced.Balanced.configure("ak-test-25ZY8HQwZPuQtDecrxb671LilUya5t5G0");

Order order = Order.Fetch("/orders/OR3BXTqXewuSy1Cu3g6N2Sjj");
BankAccount bankAccount = BankAccount.Fetch("/bank_accounts/BA2gul8YMjFWnFk0fFHXwX6g/credits");
Dictionary<string, object> creditPayload = new Dictionary<string, object>();
creditPayload.Add("amount", 5000);
Credit credit = order.CreditTo(bankAccount, creditPayload);
% endif
