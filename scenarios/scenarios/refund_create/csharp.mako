% if mode == 'definition':
Debit.Refund()
% elif mode == 'request':
Debit debit = Debit.Fetch("/debits/WD2xyaqvTmBkMjR5QCICxPoB");
Dictionary<string, string> payload = new Dictionary<string, string>();
payload.Add("amount", 3000);
payload.Add("description", "Refund for Order #1111");
Refund refund = debit.Refund(payload);
% endif
