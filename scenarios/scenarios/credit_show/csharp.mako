% if mode == 'definition':
Credit.Fetch()
% elif mode == 'request':
using Balanced;

Balanced.Balanced.configure("ak-test-1xLFE6RLC1W3P4ePiQDI4UVpRwtKcdfqL");

Credit credit = Credit.Fetch("/credits/CR5pb9ux8RYVNTwcJ3jdVF84");
% endif
