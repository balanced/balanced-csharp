BankAccount marketplaceBankAccount = Marketplace.Mine.owner_customer.bank_accounts.First();
Dictionary<string, object> creditPayload = new Dictionary<string, object>();
creditPayload.Add("amount", 2000);
creditPayload.Add("description", "Credit from order escrow to marketplace bank account");
Credit credit = order.CreditTo(marketplaceBankAccount, creditPayload);