% if mode == 'definition':
Card.Save()
% elif mode == 'request':
using Balanced;

Balanced.Balanced.configure("ak-test-25ZY8HQwZPuQtDecrxb671LilUya5t5G0");

Card card = Card.new();
card.number = 6500000000000002;
card.cvv = 123;
card.expiration_month = 12;
card.expiration_year = 3000;
card.Save();
% endif
