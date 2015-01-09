% if mode == 'definition':
Debit.dispute
% elif mode == 'request':
using Balanced;

Balanced.Balanced.configure("ak-test-1xLFE6RLC1W3P4ePiQDI4UVpRwtKcdfqL");

Debit debit = Debit.Fetch("/debits/WD4QE0i532v0eWQ6mCWCASc5");
dispute = debit.dispute;
% endif
