using Balanced;

Balanced.Balanced.configure("ak-test-DXIgzoqwN4LsoCabloqy87y42qwm1lXR");


Callback callback = new Callback();
callback.url = "{{payload.url}}";
callback.method = "{{payload.method}}";
callback.Save();