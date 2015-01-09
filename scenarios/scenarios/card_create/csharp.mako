% if mode == 'definition':
new Card()
% elif mode == 'request':
using Balanced;

Balanced.Balanced.configure("ak-test-1xLFE6RLC1W3P4ePiQDI4UVpRwtKcdfqL");

Card card = Card.new();
card.number = 5105105105105100;
card.cvv = 123;
card.Save();
% endif
