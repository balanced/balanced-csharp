Order order = Order.Fetch("{{ order_href }}");
BankAccount bankAccount = BankAccount.Fetch("{{ bank_account_href }}");
Dictionary<string, object> creditPayload = new Dictionary<string, object>();
creditPayload.Add("amount", {{payload.amount}});
Credit credit = order.CreditTo(bankAccount, creditPayload);