using Balanced;

Balanced.Balanced.configure("{{ api_key }}");

ApiKey key = ApiKey.Fetch("{{ uri }}");
key.Unstore();