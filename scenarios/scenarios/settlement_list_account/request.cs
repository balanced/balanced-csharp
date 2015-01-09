using Balanced;
using System.Collections.Generic;

Balanced.Balanced.configure("{{ api_key }}");

Account account = Account.Fetch("{{ href }}");
List<Settlement> settlements = accounts.settlements;