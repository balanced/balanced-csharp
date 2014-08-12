% if mode == 'definition':
ApiKey.Unstore()
% elif mode == 'request':
using Balanced;

Balanced.Balanced.configure("ak-test-DXIgzoqwN4LsoCabloqy87y42qwm1lXR");

ApiKey key = ApiKey.Fetch("/api_keys/AK10MnleWQtvlw4ZJkps2Yu1");
key.Unstore();
% endif
