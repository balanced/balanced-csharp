% if mode == 'definition':
new Card()
% elif mode == 'request':
using Balanced;

Balanced.Balanced.configure("ak-test-DXIgzoqwN4LsoCabloqy87y42qwm1lXR");

Card card = Card.new();
card.number = 5105105105105100;
card.cvv = 123;
card.Save();
% endif
