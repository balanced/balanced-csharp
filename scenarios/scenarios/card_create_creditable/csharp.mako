% if mode == 'definition':
Card.Save()
% elif mode == 'request':
using Balanced;

Balanced.Balanced.configure("ak-test-25ZY8HQwZPuQtDecrxb671LilUya5t5G0");

Card card = Card.new();
card.number = 4342561111111118;
card.name = "Johannes Bach";
card.expiration_month = 05;
card.expiration_year = 2020;
card.Save();
% endif
