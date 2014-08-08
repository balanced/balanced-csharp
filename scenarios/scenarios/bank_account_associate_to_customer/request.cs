using Balanced;

Balanced.Balanced.configure("ak-test-DXIgzoqwN4LsoCabloqy87y42qwm1lXR");

BankAccount bankAccount = BankAccount.Fetch("{{ uri }}");
bankAccount.AssociateToCustomer("{{payload.customer}}");