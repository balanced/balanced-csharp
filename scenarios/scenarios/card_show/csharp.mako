% if mode == 'definition':
Card.Fetch()
% elif mode == 'request':
using Balanced;

Balanced.Balanced.configure("ak-test-1xLFE6RLC1W3P4ePiQDI4UVpRwtKcdfqL");

Card card = Card.Fetch("/cards/CC2SHYWrrAN9Vvl3vuznGeHu");
% endif
