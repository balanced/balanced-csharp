% if mode == 'definition':
Order.Credit()
% elif mode == 'request':
Order order = Order.Fetch("/orders/OR26ekFGTu5M22gr9fIKOMhH");
BankAccount bankAccount = BankAccount.Fetch("/bank_accounts/BA1rgE1dqOFhqRaZydCenoBr/credits");
Dictionary<string, object> creditPayload = new Dictionary<string, object>();
creditPayload.Add("amount", 5000);
Credit credit = order.CreditTo(bankAccount, creditPayload);
% endif
