% if mode == 'definition':
Card.Fetch()
% elif mode == 'request':
using Balanced;

Balanced.Balanced.configure("ak-test-DXIgzoqwN4LsoCabloqy87y42qwm1lXR");

Card card = Card.Fetch("/cards/CC1O7vho1znJiHNRkKe11EYF");
% endif
