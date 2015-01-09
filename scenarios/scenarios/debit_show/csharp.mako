% if mode == 'definition':
Debit.Fetch()
% elif mode == 'request':
using Balanced;

Balanced.Balanced.configure("ak-test-1xLFE6RLC1W3P4ePiQDI4UVpRwtKcdfqL");

Debit debit = Debit.Fetch("/debits/WD4LT3ghEgoGK9z4wUQCsKUU");
% endif
