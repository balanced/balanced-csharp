% if mode == 'definition':
Card.AssociateToCustomer()
% elif mode == 'request':
using Balanced;

Balanced.Balanced.configure("ak-test-1xLFE6RLC1W3P4ePiQDI4UVpRwtKcdfqL");

Card card = Card.Fetch("/cards/CC3bspNmYxyJu9J52MbgArDy");
card.AssociateToCustomer("/customers/CU4CZc7Xjn8gGJXl1LyzZk7S");
% endif
