BankAccount bankAccount = BankAccount.Fetch("{{ uri }}");
bankAccount.AssociateToCustomer("{{payload.customer}}");