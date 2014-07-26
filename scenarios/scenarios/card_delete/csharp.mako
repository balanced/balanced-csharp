% if mode == 'definition':
Card.Unstore()
% elif mode == 'request':
Card card = Card.Fetch("/cards/CC1O7vho1znJiHNRkKe11EYF");
card.Unstore();
% endif
