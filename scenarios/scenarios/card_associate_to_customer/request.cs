Card card = Card.Fetch("{{ uri }}");
card.AssociateToCustomer("{{payload.customer}}");