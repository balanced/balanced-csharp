% if mode == 'definition':
new Customer()
% elif mode == 'request':
Customer customer = Customer.new();
Dictionary<string, string> address = new Dictionary<string, string>();
address.Add("postal_code", "");
          
customer.name = "";
customer.dob_month = "";
customer.dob_year = "";
customer.address = address;
customer.Save();
% endif
