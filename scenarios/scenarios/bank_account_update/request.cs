BankAccount bankAccount = BankAccount.Fetch("{{ uri }}");
Dictionary<string, string> meta = new Dictionary<string, string>();
meta.Add("facebook.user_id", "{{ payload.meta.["facebook.user_id"] }}");
meta.Add("my-own-customer-id", "{{ payload.meta.["my-own-customer-id"] }}");
meta.Add("twitter.id", "{{ payload.meta.["twitter.id"] }}");
bankAccount.meta = meta;
bankAccount.Save();