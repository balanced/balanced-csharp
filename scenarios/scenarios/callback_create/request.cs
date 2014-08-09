using Balanced;

Balanced.Balanced.configure("{{ api_key }}");


Callback callback = new Callback();
callback.url = "{{payload.url}}";
callback.method = "{{payload.method}}";
callback.Save();