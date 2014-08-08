% if mode == 'definition':
BankAccountVerification.Fetch()
% elif mode == 'request':
using Balanced;

Balanced.Balanced.configure("ak-test-DXIgzoqwN4LsoCabloqy87y42qwm1lXR");

BankAccountVerification verification = BankAccountVerification.Fetch("/verifications/BZ1cqB0VfXFJ1wJbDsqsP6MB");
% endif
