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
                        f.WriteLine("% if mode == 'definition':");
                        f.WriteLine(File.ReadAllText(scenarioDir + "/definition.cs"));
                        f.WriteLine("% elif mode == 'request':");
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
