% if mode == 'definition':
Refund.Fetch()
% elif mode == 'request':
using Balanced;

Balanced.Balanced.configure("ak-test-1xLFE6RLC1W3P4ePiQDI4UVpRwtKcdfqL");

Refund refund = Refund.Fetch("/refunds/RF4zwAHHq8ifpN3M1RLEwSJD");
% endif
