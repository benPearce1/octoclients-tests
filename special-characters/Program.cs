using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Helpers;
using Octopus.Client;

namespace special_characters
{
    class Program
    {
        static void Main(string[] args)
        {
            var server = EnvironmentHelpers.GetServerUrl();
            var apiKey = EnvironmentHelpers.GetApiKey();
            var endpoint = new OctopusServerEndpoint(server, apiKey);
            var repository = new OctopusRepository(endpoint);

            var tenantResources = repository.Tenants.FindByName("Team 😄");
            ConsoleHelpers.Dump(tenantResources);

            Console.ReadKey();
        }
    }
}
