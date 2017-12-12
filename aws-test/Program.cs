using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Helpers;
using Octopus.Client;
using Octopus.Client.Model.Accounts;

namespace aws_test
{
    class Program
    {
        static void Main(string[] args)
        {
            var server = EnvironmentHelpers.GetServerUrl();
            var apiKey = EnvironmentHelpers.GetApiKey();
            var endpoint = new OctopusServerEndpoint(server, apiKey);
            var repository = new OctopusRepository(endpoint);

            var name = Guid.NewGuid().ToString();
            var newAwsAccount =
                new AmazonWebServicesAccountResource {AccessKey = "asdf", SecretKey = "bgasretb", Name = name};
            repository.Accounts.Create(newAwsAccount);

            var accounts = repository.Accounts.FindAll();
            ConsoleHelpers.Dump(accounts);

            ConsoleHelpers.Dump(accounts.Where(x => x.Name == name));
            Console.ReadLine();
            repository.Accounts.Delete(accounts.First(x => x.Name == newAwsAccount.Name));
            accounts = repository.Accounts.FindAll();
            ConsoleHelpers.Dump(accounts);


            Console.ReadLine();
        }
    }
}
