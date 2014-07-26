% if mode == 'definition':
Card.Credit()
% elif mode == 'request':
Card card = Card.Fetch("/cards/CC228EUcLHBcrAb5SrNEcIUp");
Dictionary<string, object> creditPayload = new Dictionary<string, object>();
creditPayload.Add("amount", 5000);
creditPayload.Add("description", "Some descriptive text for the debit in the dashboard");
Credit credit = card.Credit(creditPayload)
% endif
