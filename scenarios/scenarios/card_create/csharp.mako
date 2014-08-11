% if mode == 'definition':
new Card()
% elif mode == 'request':
using Balanced;

Balanced.Balanced.configure("ak-test-25ZY8HQwZPuQtDecrxb671LilUya5t5G0");

Card card = Card.new();
card.number = 5105105105105100;
card.cvv = 123;
card.Save();
% endif
