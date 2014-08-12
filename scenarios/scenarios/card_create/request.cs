using Balanced;

Balanced.Balanced.configure("{{ api_key }}");

Card card = Card.new();
card.number = {{ payload.number }};
card.cvv = {{ payload.cvv }};
card.Save();