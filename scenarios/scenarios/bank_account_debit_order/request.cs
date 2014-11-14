using Balanced;
using System.Collections.Generic;

Balanced.Balanced.configure("{{ api_key }}");

Order order = Order.Fetch("{{ order_href }}");
BankAccount bankAccount = Card.Fetch("{{ bank_account_href }}");
Dictionary<string, object> debitPayload = new Dictionary<string, object>();
debitPayload.Add("amount", {{payload.amount}});
Debit debit = order.DebitFrom(bankAccount, debitPayload);