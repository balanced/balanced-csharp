% if mode == 'definition':
Reversal.Fetch()
% elif mode == 'request':
using Balanced;

Balanced.Balanced.configure("ak-test-25ZY8HQwZPuQtDecrxb671LilUya5t5G0");


Reversal reversal = Reversal.Fetch("/reversals/RV5Fc1aJCtoFdUKBVdErGJed");
% endif
