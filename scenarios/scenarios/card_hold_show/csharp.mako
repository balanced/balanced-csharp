% if mode == 'definition':
CardHold.Fetch()
% elif mode == 'request':
using Balanced;

Balanced.Balanced.configure("ak-test-1xLFE6RLC1W3P4ePiQDI4UVpRwtKcdfqL");

CardHold cardHold = CardHold.fetch("/card_holds/HL44qbPoom3uVlTlEGBZV7z2");
% endif
