using Balanced;
using System.Collections.Generic;

Balanced.Balanced.configure("ak-test-DXIgzoqwN4LsoCabloqy87y42qwm1lXR");

CardHold cardHold = CardHold.fetch("{{ uri }}");
Dictionary<string, string> meta = new Dictionary<string, string>();
meta.Add("holding.for.user_id", "{{ payload.meta.["holding.for"] }}");
meta.Add("meaningful.key", "{{ payload.meta.["meaningful.key"] }}");
cardHold.meta = meta;
cardHold.Save();