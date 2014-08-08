BankAccount bankAccount = BankAccount.Fetch("{{ bank_account_href }}");
List<Credit> credits = bankAccount.credits;