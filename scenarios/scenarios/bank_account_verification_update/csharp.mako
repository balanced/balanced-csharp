% if mode == 'definition':
BankAccountVerification.Confirm()
% elif mode == 'request':
using Balanced;

Balanced.Balanced.configure("ak-test-DXIgzoqwN4LsoCabloqy87y42qwm1lXR");

BankAccountVerification verification = BankAccountVerification.Fetch("/verifications/BZ1cqB0VfXFJ1wJbDsqsP6MB");
verification.Confirm(1, 1);
% endif
