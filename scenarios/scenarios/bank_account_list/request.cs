using Balanced;
using System.Collections.Generic;

Balanced.Balanced.configure("{{ api_key }}");

List<BankAccount> bankAccounts = BankAccount.Query().All();