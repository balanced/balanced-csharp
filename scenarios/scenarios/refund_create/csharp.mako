% if mode == 'definition':
Debit.Refund()
% elif mode == 'request':
using Balanced;

Balanced.Balanced.configure("ak-test-DXIgzoqwN4LsoCabloqy87y42qwm1lXR");

Debit debit = Debit.Fetch("/debits/WD2xyaqvTmBkMjR5QCICxPoB");
Dictionary<string, string> payload = new Dictionary<string, string>();
payload.Add("amount", 3000);
payload.Add("description", "Refund for Order #1111");
Refund refund = debit.Refund(payload);
% endif
