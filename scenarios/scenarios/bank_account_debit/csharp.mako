% if mode == 'definition':
BankAccount.Debit()
% elif mode == 'request':
using Balanced;
using System.Collections.Generic;

Balanced.Balanced.configure("ak-test-25ZY8HQwZPuQtDecrxb671LilUya5t5G0");

BankAccount bankAccount = BankAccount.Fetch("/bank_accounts/BA17zYxBNrmg9isvicjz9Ae4");
Dictionary<string, object> payload = new Dictionary<string, object>();
payload.Add("amount", 5000);
payload.Add("appears_on_statement_as", "Statement text");
payload.Add("description", "Some descriptive text for the debit in the dashboard");
Debit debit = bankAccount.Debit(payload);
% endif
