% if mode == 'definition':
BankAccountVerification.Fetch()
% elif mode == 'request':
using Balanced;

Balanced.Balanced.configure("ak-test-1xLFE6RLC1W3P4ePiQDI4UVpRwtKcdfqL");

BankAccountVerification verification = BankAccountVerification.Fetch("/verifications/BZ5XxtvPAMXrKcmyaN1DFqfK");
% endif
