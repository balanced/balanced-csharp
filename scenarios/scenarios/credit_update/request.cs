Credit credit = Credit.Fetch("{{ uri }}");
Dictionary<string, string> meta = new Dictionary<string, string>();
meta.Add("facebook.id", "{{ payload.meta.["facebook.id"] }}");
meta.Add("anykey", "{{ payload.meta.["anykey"] }}");
credit.meta = meta;
credit.Save();
