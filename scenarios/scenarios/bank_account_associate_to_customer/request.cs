using Balanced;

Balanced.Balanced.configure("{{ api_key }}");

BankAccount bankAccount = BankAccount.Fetch("{{ uri }}");
bankAccount.AssociateToCustomer("{{payload.customer}}");