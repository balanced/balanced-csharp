using Balanced;

Balanced.Balanced.configure("{{ api_key }}");

BankAccountVerification verification = BankAccountVerification.Fetch("{{uri }}");
verification.Confirm({{payload.amount_1}}, {{payload.amount_1}});