Card card = Card.new();
card.number = {{ payload.number }};
card.cvv = {{ payload.cvv }};
card.expiration_month = {{ payload.expiration_month }};
card.expiration_year = {{ payload.expiration_year }};
card.Save();