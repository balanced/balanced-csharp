BankAccount bankAccount = Marketplace.Mine.owner_customer.bank_accounts.First();
Dictionary<string, object> payload = new Dictionary<string, object>();
payload.Add("amount", 2000000);
payload.Add("description", "Pre-fund Balanced escrow");
Debit debit = bankAccount.Debit(payload);