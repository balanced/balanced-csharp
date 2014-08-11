% if mode == 'definition':
BankAccountVerification.Fetch()
% elif mode == 'request':
using Balanced;

Balanced.Balanced.configure("ak-test-25ZY8HQwZPuQtDecrxb671LilUya5t5G0");

BankAccountVerification verification = BankAccountVerification.Fetch("/verifications/BZ1eMAsKt13lIj2SkvvHlxfT");
% endif
