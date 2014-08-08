using Balanced;

Balanced.Balanced.configure("ak-test-DXIgzoqwN4LsoCabloqy87y42qwm1lXR");

Card card = Card.new();
card.number = {{ payload.number }};
card.cvv = {{ payload.cvv }};
card.Save();