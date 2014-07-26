% if mode == 'definition':
Card.AssociateToCustomer()
% elif mode == 'request':
Card card = Card.Fetch("/cards/CC1VmEgD058TlNlPbcGiCac5");
card.AssociateToCustomer("/customers/CU1q8McSAi35Nb3sqPlMemWN");
% endif
