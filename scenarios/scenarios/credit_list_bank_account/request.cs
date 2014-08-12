using Balanced;
using System.Collections.Generic;

Balanced.Balanced.configure("{{ api_key }}");

BankAccount bankAccount = BankAccount.Fetch("{{ bank_account_href }}");
List<Credit> credits = bankAccount.credits;