Dictionary<string, object> settlementPayload = new Dictionary<string, object>();
settlementPayload.Add("description", "ThingsCo");
settlementPayload.Add("description", "A simple description");
settlementPayload.Add("funding_instrument", ba.href);

Settlement settlement = account.Settle(settlementPayload);