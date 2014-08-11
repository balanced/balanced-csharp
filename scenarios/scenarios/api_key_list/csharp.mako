% if mode == 'definition':
ApiKey.Query()
% elif mode == 'request':
using Balanced;
using System.Collections.Generic;

Balanced.Balanced.configure("ak-test-25ZY8HQwZPuQtDecrxb671LilUya5t5G0");

List<ApiKey> keys = ApiKey.Query().All();
% endif
