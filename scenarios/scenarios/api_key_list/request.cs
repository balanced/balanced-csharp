using Balanced;
using System.Collections.Generic;

Balanced.Balanced.configure("{{ api_key }}");

List<ApiKey> keys = ApiKey.Query().All();