% if mode == 'definition':
BankAccount.Credit()
% elif mode == 'request':
using Balanced;
using System.Collections.Generic;

Balanced.Balanced.configure("ak-test-25ZY8HQwZPuQtDecrxb671LilUya5t5G0");

BankAccount bankAccount = BankAccount.Fetch("/bank_accounts/BA2gul8YMjFWnFk0fFHXwX6g");
Dictionary<string, object> creditPayload = new Dictionary<string, object>();
creditPayload.Add("amount", 5000 );
Credit credit = bankAccount.Credit(creditPayload);
% endif
