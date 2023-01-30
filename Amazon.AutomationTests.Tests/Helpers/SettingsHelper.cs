using Amazon.AutomationTests.Base;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Amazon.AutomationTests.Tests.Helpers
{
    public static class SettingsHelper
    {
        public static IConfiguration InitConfiguration(string[]? args = null)
        {
            string? environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            Console.WriteLine($"Environment name: {environment}.");
            if (string.IsNullOrEmpty(environment))
            {
                environment = "Development";
            }

            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            configurationBuilder = configurationBuilder
                .AddJsonFile(EnvironmentHelper.AssemblyDirectory + Path.DirectorySeparatorChar + "appsettings.json", optional: true)
                .AddJsonFile(EnvironmentHelper.AssemblyDirectory + Path.DirectorySeparatorChar + $"appsettings.{environment}.json", optional: true)
                .AddEnvironmentVariables();

            if (args != null && args.Length > 0)
            {
                configurationBuilder = configurationBuilder.AddCommandLine(args);
            }

            return configurationBuilder.Build();
        }

        public static void InitUrlSettings(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<UrlsSettings>(options => configuration.GetSection("Browser").Bind(options));
        }
    }
}
