% if mode == 'definition':
Card.Hold()
% elif mode == 'request':
Card card = Card.Fetch("/cards/CC1BHJUqEMEy4k7M7KPcZyOF");
Dictionary<string, object> holdPayload = new Dictionary<string, object>();
holdPayload.Add("amount", 5000);
holdPayload.Add("description", "Some descriptive text for the debit in the dashboard");
CardHold cardHold = card.Hold(holdPayload);
cardHold.Save();
% endif
