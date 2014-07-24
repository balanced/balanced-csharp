% if mode == 'definition':
BankAccount.Save()
% elif mode == 'request':
BankAcount bankAccount = BankAccount.Fetch( "/bank_accounts/BA1iWjnIUhEkl5bORJGRGd9T" );
Dictionary<string, string> meta = new Dictionary<string, string>();
meta.Add( "facebook.user_id", "0192837465" )
meta.Add( "my-own-customer-id", "12345" )
meta.Add( "twitter.id", "1234987650" )
bankAccount.meta = meta;
bankAccount.Save();
% endif
