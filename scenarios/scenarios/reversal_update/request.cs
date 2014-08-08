Reversal reversal = Reversal.Fetch("{{uri}}");
Dictionary<string, string> meta = new Dictionary<string, string>();
meta.Add("refund.reason", "{{ payload.meta.["refund.reason"] }}");
meta.Add("user.notes", "{{ payload.meta.["user.notes"] }}");
meta.Add("user.satisfaction", "{{ payload.meta.["user.satisfaction"] }}");
reversal.meta = meta;
reversal.description = "{{payload.description}}";
reversal.Save();