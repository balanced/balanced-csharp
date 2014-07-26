BankAcount bankAccount = BankAccount.Fetch("{{ bank_account_uri }}");
BankAccountVerification verification = bankAccount.Verify();
bankAccount.Reload();