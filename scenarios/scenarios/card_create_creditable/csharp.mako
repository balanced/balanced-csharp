% if mode == 'definition':
Card.Save()
% elif mode == 'request':
Card card = Card.new();
card.number = 4342561111111118;
card.cvv = ;
card.expiration_month = 05;
card.expiration_year = 2020;
card.Save();
% endif
