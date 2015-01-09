% if mode == 'definition':
Settlement.Fetch()
% elif mode == 'request':
using Balanced;

Balanced.Balanced.configure("ak-test-1xLFE6RLC1W3P4ePiQDI4UVpRwtKcdfqL");

Settlement settlement = Settlement.Fetch("/settlements/ST5xMBEiT3t2Stt2ia4Svl2d");
% endif
