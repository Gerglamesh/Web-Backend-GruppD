
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace EngineClasses
{
    public static class ConnectionSetup
    {
        public static string GetConnectionString()
        {
            var environmentName = Environment.GetEnvironmentVariable("SettingsEnvironment");         //denna får till envvar.json filen   // denna går till envvar.dev.json
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("EnvVars.json").AddJsonFile($"EnvVars.{environmentName}.json", optional: true);
            var config = builder.Build();

            return config.GetConnectionString("DefaultConnection");
        }
    }
}