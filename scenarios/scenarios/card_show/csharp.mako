% if mode == 'definition':
Card.Fetch()
% elif mode == 'request':
using Balanced;

Balanced.Balanced.configure("ak-test-25ZY8HQwZPuQtDecrxb671LilUya5t5G0");

Card card = Card.Fetch("/cards/CC33DRVrekWpiHYjxSdVuqWc");
% endif
