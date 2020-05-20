using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace EngineClasses
{
    public static class ConnectionSetup
    {
        public static string GetConnectionString()
        {
            var environmentName = Environment.GetEnvironmentVariable("SettingsEnvironment");
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("EnvironmentSettings.json").AddJsonFile($"SpecificEnvironmentSettings.{environmentName}.json", optional: true);
            var config = builder.Build();

            return config.GetConnectionString("DefaultConnection");
        }
    }
}