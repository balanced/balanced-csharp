% if mode == 'definition':
BankAccountVerification.Confirm()
% elif mode == 'request':
BankAccountVerification verification = BankAccountVerification.Fetch( "/verifications/BZ1cqB0VfXFJ1wJbDsqsP6MB" );
verification.Confirm(1, 1);
% endif
