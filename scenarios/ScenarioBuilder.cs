using DotLiquid;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Scenarios
{
    public class ScenarioBuilder
    {
        private const string SCENARIO_CACHE_URL = "https://raw.githubusercontent.com/balanced/balanced-docs/master/scenario.cache";
        private const string SCENARIOS_DIR = "../../scenarios/";

        public static void Main()
        {
            WebClient myWebClient = new WebClient();
            var scenarioCache = myWebClient.DownloadString(SCENARIO_CACHE_URL);
            JavaScriptSerializer js = new JavaScriptSerializer();
            var json = js.Deserialize<dynamic>(scenarioCache);

            string[] scenarioDirs = Directory.GetDirectories(SCENARIOS_DIR);

            foreach (string scenarioDir in scenarioDirs)
            {
                var scenarioName = scenarioDir.Substring(SCENARIOS_DIR.Length);

                try
                {
                    Console.WriteLine("Rendering " + scenarioName);

                    var scenarioRequestJSON = json[scenarioName]["request"];
                    Template template = Template.Parse(File.ReadAllText(scenarioDir + "/request.cs"));
                    var renderedRequest = template.Render(Hash.FromDictionary(scenarioRequestJSON));
                    
                    using (System.IO.StreamWriter f = new System.IO.StreamWriter(scenarioDir + "/csharp.mako"))
                    {
                        List<string> collectionList = new List<string>();
                        collectionList.Add("../../scenarios/api_key_list");
                        collectionList.Add("../../scenarios/bank_account_credit");
                        collectionList.Add("../../scenarios/bank_account_debit");
                        collectionList.Add("../../scenarios/bank_account_list");
                        collectionList.Add("../../scenarios/bank_account_update");
                        collectionList.Add("../../scenarios/callback_list");
                        collectionList.Add("../../scenarios/card_credit");
                        collectionList.Add("../../scenarios/card_debit");
                        collectionList.Add("../../scenarios/card_debit_dispute");
                        collectionList.Add("../../scenarios/card_hold_capture");
                        collectionList.Add("../../scenarios/card_hold_create");
                        collectionList.Add("../../scenarios/card_hold_list");
                        collectionList.Add("../../scenarios/card_hold_update");
                        collectionList.Add("../../scenarios/card_list");
                        collectionList.Add("../../scenarios/card_update");
                        collectionList.Add("../../scenarios/credit_list");
                        collectionList.Add("../../scenarios/credit_list_bank_account");
                        collectionList.Add("../../scenarios/credit_order");
                        collectionList.Add("../../scenarios/credit_update");
                        collectionList.Add("../../scenarios/customer_create");
                        collectionList.Add("../../scenarios/customer_list");
                        collectionList.Add("../../scenarios/customer_update");
                        collectionList.Add("../../scenarios/debit_list");
                        collectionList.Add("../../scenarios/debit_order");
                        collectionList.Add("../../scenarios/debit_update");
                        collectionList.Add("../../scenarios/dispute_list");
                        collectionList.Add("../../scenarios/event_list");
                        collectionList.Add("../../scenarios/order_create");
                        collectionList.Add("../../scenarios/order_list");
                        collectionList.Add("../../scenarios/order_update");
                        collectionList.Add("../../scenarios/refund_create");
                        collectionList.Add("../../scenarios/refund_list");
                        collectionList.Add("../../scenarios/refund_update");
                        collectionList.Add("../../scenarios/reversal_create");
                        collectionList.Add("../../scenarios/reversal_list");
                        collectionList.Add("../../scenarios/reversal_update");

                        f.WriteLine("% if mode == 'definition':");
                        f.WriteLine(File.ReadAllText(scenarioDir + "/definition.cs"));
                        f.WriteLine("% elif mode == 'request':");
                        if (collectionList.Contains(scenarioDir))
                        {
                            f.WriteLine("using Balanced;");
                            f.WriteLine("using System.Collections.Generic;");
                            f.WriteLine("");
                            f.WriteLine("Balanced.Balanced.configure(\"ak-test-DXIgzoqwN4LsoCabloqy87y42qwm1lXR\");");
                        }
                        else
                        {
                            f.WriteLine("using Balanced;");
                            f.WriteLine("");
                            f.WriteLine("Balanced.Balanced.configure(\"ak-test-DXIgzoqwN4LsoCabloqy87y42qwm1lXR\");");
                        }
                        f.WriteLine("");
                        f.WriteLine(renderedRequest);
                        f.WriteLine("% endif");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Unable to render scenario - " + scenarioName);
                }
                
            }

            
        }
    }
}
