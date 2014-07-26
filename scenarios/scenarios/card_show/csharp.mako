% if mode == 'definition':
Card.Fetch()
% elif mode == 'request':
Card card = Card.Fetch("/cards/CC1O7vho1znJiHNRkKe11EYF");
% endif
