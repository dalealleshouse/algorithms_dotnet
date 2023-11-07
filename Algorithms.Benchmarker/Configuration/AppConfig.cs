namespace Algorithms.Benchmarker.Configuration
{
    using System;
    using Microsoft.Extensions.Configuration;

    public class AppConfig
    {
        private static AppConfig config = null;

        public static AppConfig Config
        {
            get { return config; }
        }

        public MatrixOperations MatrixOperations { get; set; }

        public RunningMedian RunningMedian { get; set; }

        public static void InitConfg()
        {
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var builder = new ConfigurationBuilder()
                .AddJsonFile($"appsettings.json", true, true)
                .AddJsonFile($"appsettings.{env}.json", true, true)
                .AddEnvironmentVariables();

            config = builder.Build().Get<AppConfig>();
        }
    }
}
