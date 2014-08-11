% if mode == 'definition':
ApiKey.Fetch()
% elif mode == 'request':
using Balanced;
using System.Collections.Generic;

Balanced.Balanced.configure("ak-test-25ZY8HQwZPuQtDecrxb671LilUya5t5G0");

ApiKey key = ApiKey.Fetch("/api_keys/AKJnLWedoBhUHpdhoGEOPew");
% endif
