% if mode == 'definition':
Customer.accounts
% elif mode == 'request':
using Balanced;
using System.Collections.Generic;

Balanced.Balanced.configure("ak-test-1xLFE6RLC1W3P4ePiQDI4UVpRwtKcdfqL");

Customer customer = Customer.Fetch("/customers/CU4CZc7Xjn8gGJXl1LyzZk7S");
List<Account> accounts = customer.accounts;
% endif
