using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Helpers;
using Octopus.Client;
using Octopus.Client.Extensibility;

namespace client_427
{
    class Program
    {
        static void Main(string[] args)
        {
            var server = EnvironmentHelpers.GetServerUrl();
            var apiKey = EnvironmentHelpers.GetApiKey();
            var endpoint = new OctopusServerEndpoint(server, apiKey);
            var repository = new OctopusRepository(endpoint);

            var project = repository.Projects.GetAll().First();


            //string deploymentProcess = project.Link("DeploymentProcess");
            
            //ConsoleHelpers.Dump(project.Links.Where(x => x.Key.Equals("DeploymentProcess")));
            KeyValuePair<string, Href> deploymentProcess = project.Links.Where(l => l.Key == "DeploymentProcess").FirstOrDefault();

            ConsoleHelpers.Dump(deploymentProcess);

            Console.ReadLine();
        }
    }
}
