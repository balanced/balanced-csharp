using Balanced;
using System.Collections.Generic;

Balanced.Balanced.configure("{{ api_key }}");

List<Card> cards = Card.Query().All();