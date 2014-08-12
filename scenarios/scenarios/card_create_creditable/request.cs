using Balanced;

Balanced.Balanced.configure("{{ api_key }}");

Card card = Card.new();
card.number = {{ payload.number }};
card.name = "{{ payload.name }}";
card.expiration_month = {{ payload.expiration_month }};
card.expiration_year = {{ payload.expiration_year }};
card.Save();