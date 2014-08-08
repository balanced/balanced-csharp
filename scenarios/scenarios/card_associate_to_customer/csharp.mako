% if mode == 'definition':
Card.AssociateToCustomer()
% elif mode == 'request':
using Balanced;

Balanced.Balanced.configure("ak-test-DXIgzoqwN4LsoCabloqy87y42qwm1lXR");

Card card = Card.Fetch("/cards/CC1VmEgD058TlNlPbcGiCac5");
card.AssociateToCustomer("/customers/CU1q8McSAi35Nb3sqPlMemWN");
% endif
