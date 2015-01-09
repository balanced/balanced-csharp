% if mode == 'definition':
Card.Save()
% elif mode == 'request':
using Balanced;

Balanced.Balanced.configure("ak-test-1xLFE6RLC1W3P4ePiQDI4UVpRwtKcdfqL");

Card card = Card.new();
card.number = 6500000000000002;
card.cvv = 123;
card.expiration_month = 12;
card.expiration_year = 3000;
card.Save();
% endif
