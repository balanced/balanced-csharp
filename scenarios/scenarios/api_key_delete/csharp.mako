% if mode == 'definition':
ApiKey.Unstore()
% elif mode == 'request':
ApiKey key = ApiKey.Fetch( "/api_keys/AK10MnleWQtvlw4ZJkps2Yu1" );
key.Unstore()
% endif
