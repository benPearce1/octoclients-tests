using System;
using System.Linq;

namespace Helpers
{
    public static class EnvironmentHelpers
    {
        public static string GetServerUrl()
        {
            var value = GetEnvironmentVariable("octoserver", "octopusserver", "octopus-server", "octoserverurl");
            return value;
        }

        public static string GetApiKey()
        {
            var value = GetEnvironmentVariable("apikey", "octoapikey");
            return value;
        }

        private static string GetEnvironmentVariable(params string[] variables)
        {
            if (variables.Any())
            {
                foreach (var variable in variables)
                {
                    var value = Environment.GetEnvironmentVariable(variable);
                    if (!string.IsNullOrEmpty(value))
                    {
                        return value;
                    }
                }
            }

            return null;
        }
    }
}
