% if mode == 'definition':
BankAccountVerification.Fetch()
% elif mode == 'request':
BankAccountVerification verification = BankAccountVerification.Fetch( "/verifications/BZ1cqB0VfXFJ1wJbDsqsP6MB" );
% endif
