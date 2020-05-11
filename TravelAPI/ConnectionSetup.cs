
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
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile($"SpecificEnvironmentSettings.{environmentName}.json", optional: true).AddJsonFile("EnvironmentSettings.json");
            var config = builder.Build();

            return config.GetConnectionString("DefaultConnection");
        }
    }
}