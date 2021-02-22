using Microsoft.Extensions.Configuration;
using System;

namespace Algorithms.Benchmarker.Configuration
{
    public class AppConfig
    {
        public static AppConfig config = null;

        public static void InitConfg()
        {
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var builder = new ConfigurationBuilder()
                .AddJsonFile($"appsettings.json", true, true)
                .AddJsonFile($"appsettings.{env}.json", true, true)
                .AddEnvironmentVariables();

            config = builder.Build().Get<AppConfig>();
        }

        public MatrixOperations MatrixOperations { get; set; }
        public RunningMedian RunningMedian { get; set; }
    }
}
