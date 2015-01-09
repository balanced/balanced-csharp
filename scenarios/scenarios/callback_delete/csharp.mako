% if mode == 'definition':
Callback.Unstore()
% elif mode == 'request':
using Balanced;

Balanced.Balanced.configure("ak-test-1xLFE6RLC1W3P4ePiQDI4UVpRwtKcdfqL");

Callback callback = Callback.Fetch("/callbacks/CB3BP8jjVy8RBUFdb2fYw0mh");
callback.Unstore();
% endif
