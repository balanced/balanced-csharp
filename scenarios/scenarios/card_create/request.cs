Card card = Card.new();
card.number = {{ payload.number }};
card.cvv = {{ payload.cvv }};
card.Save();