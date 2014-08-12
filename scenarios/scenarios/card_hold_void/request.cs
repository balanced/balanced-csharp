using Balanced;

Balanced.Balanced.configure("{{ api_key }}");

CardHold cardHold = CardHold.fetch("{{ uri }}");
cardHold.Unstore();