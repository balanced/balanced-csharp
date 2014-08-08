% if mode == 'definition':
Debit.dispute
% elif mode == 'request':
Debit debit = Debit.Fetch("/debits/WD2CafjTjONDtHAfyMLIrg45");
dispute = debit.dispute;
% endif
