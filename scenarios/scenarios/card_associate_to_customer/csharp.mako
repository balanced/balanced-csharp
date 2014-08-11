% if mode == 'definition':
Card.AssociateToCustomer()
% elif mode == 'request':
using Balanced;

Balanced.Balanced.configure("ak-test-25ZY8HQwZPuQtDecrxb671LilUya5t5G0");

Card card = Card.Fetch("/cards/CC3IBNr3erYpVuuZDyWNFfet");
card.AssociateToCustomer("/customers/CU40AyvBB6ny9u3oelCwyc3C");
% endif
