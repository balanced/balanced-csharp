BankAccount bankAccount = BankAccount.Fetch("{{ bank_account_uri }}");
BankAccountVerification verification = bankAccount.Verify();