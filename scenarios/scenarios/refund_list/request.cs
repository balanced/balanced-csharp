using Balanced;
using System.Collections.Generic;

Balanced.Balanced.configure("{{ api_key }}");

List<Refund> refunds = Refund.Query().All();