% if mode == 'definition':
Debit.Fetch()
% elif mode == 'request':
Dispute dispute = Dispute.Fetch("/disputes/DT2Ofhtver9y9vsv5NvcZ21l");
% endif
