% if mode == 'definition':
CardHold.Fetch()
% elif mode == 'request':
using Balanced;

Balanced.Balanced.configure("ak-test-25ZY8HQwZPuQtDecrxb671LilUya5t5G0");

CardHold cardHold = CardHold.fetch("/card_holds/HL2F8jlnySjVKidwfXgBYZMY");
% endif
