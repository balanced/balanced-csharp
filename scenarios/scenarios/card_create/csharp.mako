% if mode == 'definition':
Card.AssociateToCustomer()
% elif mode == 'request':
Card card = Card.new();
card.number = 5105105105105100;
card.cvv = 123;
card.Save();
% endif
