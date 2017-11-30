using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Helpers;
using Octopus.Client;
using Octopus.Client.Extensibility.Authentication.Guest.Configuration;

namespace configext47
{
    class Program
    {
        static void Main(string[] args)
        {
            var server = EnvironmentHelpers.GetServerUrl();
            var apiKey = EnvironmentHelpers.GetApiKey();
            var endpoint = new OctopusServerEndpoint(server, apiKey);
            var repository = new OctopusRepository(endpoint);

            var guest = repository.Configuration.Get<GuestConfigurationResource>();
            ConsoleHelpers.Dump(guest);
            guest.IsEnabled = !guest.IsEnabled;
            guest = repository.Configuration.Modify(guest);
            ConsoleHelpers.Dump(guest);
            Console.ReadLine();
        }
    }
}
