using Balanced;

Balanced.Balanced.configure("{{ api_key }}");

Debit debit = Debit.Fetch("{{ debit_href }}");
dispute = debit.dispute;