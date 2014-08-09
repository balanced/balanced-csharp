using Balanced;
using System.Collections.Generic;

Balanced.Balanced.configure("{{ api_key }}");

List<CardHold> cardHolds = CardHold.Query().All();