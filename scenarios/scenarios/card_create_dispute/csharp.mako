% if mode == 'definition':
Card.Save()
% elif mode == 'request':
using Balanced;

Balanced.Balanced.configure("ak-test-DXIgzoqwN4LsoCabloqy87y42qwm1lXR");

Card card = Card.new();
card.number = 6500000000000002;
card.cvv = 123;
card.expiration_month = 12;
card.expiration_year = 3000;
card.Save();
% endif
