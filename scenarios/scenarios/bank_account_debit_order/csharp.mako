% if mode == 'definition':
Order.DebitFrom()
% elif mode == 'request':
using Balanced;
using System.Collections.Generic;

Balanced.Balanced.configure("ak-test-25ZY8HQwZPuQtDecrxb671LilUya5t5G0");

Order order = Order.Fetch("/orders/OR5sl2RJVnbwEf45nq5eATdz");
BankAccount bankAccount = Card.Fetch("/bank_accounts/BA17zYxBNrmg9isvicjz9Ae4");
Dictionary<string, object> debitPayload = new Dictionary<string, object>();
debitPayload.Add("amount", 5000);
Debit debit = order.DebitFrom(bankAccount, debitPayload);
% endif
