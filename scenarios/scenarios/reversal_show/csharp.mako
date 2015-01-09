% if mode == 'definition':
Reversal.Fetch()
% elif mode == 'request':
using Balanced;

Balanced.Balanced.configure("ak-test-1xLFE6RLC1W3P4ePiQDI4UVpRwtKcdfqL");


Reversal reversal = Reversal.Fetch("/reversals/RV5xRK6ZoaXMhboMamfdfm85");
% endif
