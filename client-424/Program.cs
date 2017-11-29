using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Helpers;
using Octopus.Client;
using Octopus.Client.Model;

namespace client_424
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

            KeyValuePair<string, Href> deploymentProcess = project.Links.Where(l => l.Key.Equals("DeploymentProcess")).FirstOrDefault();

            ConsoleHelpers.Dump(deploymentProcess);

            //return _octopus.Repository.Client.Get<ReleaseTemplateResource>(deploymentProcess.Value + "/template?channel=" + templateChannel.Id);

            Console.ReadLine();
        }
    }
}
