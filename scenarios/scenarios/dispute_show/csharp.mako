% if mode == 'definition':
Debit.Fetch()
% elif mode == 'request':
using Balanced;

Balanced.Balanced.configure("ak-test-1xLFE6RLC1W3P4ePiQDI4UVpRwtKcdfqL");

Dispute dispute = Dispute.Fetch("/disputes/DT4WXjGGzPSsqYuPfWaKHDsf");
% endif
