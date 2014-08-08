% if mode == 'definition':
Order.CreditTo()
% elif mode == 'request':
using Balanced;

Balanced.Balanced.configure("ak-test-DXIgzoqwN4LsoCabloqy87y42qwm1lXR");

Order order = Order.Fetch("/orders/OR26ekFGTu5M22gr9fIKOMhH");
BankAccount bankAccount = BankAccount.Fetch("/bank_accounts/BA1rgE1dqOFhqRaZydCenoBr/credits");
Dictionary<string, object> creditPayload = new Dictionary<string, object>();
creditPayload.Add("amount", 5000);
Credit credit = order.CreditTo(bankAccount, creditPayload);
% endif
