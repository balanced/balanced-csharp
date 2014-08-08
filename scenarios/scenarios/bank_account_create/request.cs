BankAccount bankAccount = BankAccount.new();
bankAccount.account_number = "{{ payload.account_number }}";
bankAccount.routing_number = "{{ payload.routing_number }}";
bankAccount.account_type = "{{ payload.account_type }}";
bankAccount.name = "{{ payload.name }}";
bankAccount.save();