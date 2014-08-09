// bank_account_href is the stored href for the BankAccount
// order_href is the stored href for the Order
BankAccount bankAccount = BankAccount.Fetch(bank_account_href);
Dictionary<string, object> creditPayload = new Dictionary<string, object>();
creditPayload.Add("amount", 5000);
creditPayload.Add("order", order_href);
Credit credit = bankAccount.Credit(creditPayload);