% if mode == 'definition':
Callback.Unstore()
% elif mode == 'request':
Callback callback = Callback.Fetch("/callbacks/CB1vrfo2iNNen2ApNaVuPqzX");
callback.Unstore();
% endif
