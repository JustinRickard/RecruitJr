using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.FileExtensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using RecruitJr.Core.Classes;
using RecruitJr.Core.Helpers;
using RecruitJr.Core.Interfaces.Repositories;
using RecruitJr.Core.ExtensionMethods;
using RecruitJr.Core.Interfaces.Helpers;
using RecruitJr.DAL.MongoDB.Repositories;
using RecruitJr.DAL.MongoDB.ExtensionMethods;
using RecruitJr.DB.Seed.Common.ExtensionMethods;

namespace RecruitJr.DB.Seed.MongoDB.Helpers
{
    public static class ConfigurationHelper
    {
        public static IConfigurationRoot BuildConfig () {
            var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                    // .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
            var configuration = builder.Build();

            return configuration;
        }

        public static IServiceProvider BuildServiceProvider(IConfigurationRoot config) {
                IServiceCollection services = new ServiceCollection()
                    .AddOptions()
                    .Configure<AppSettings>(config.GetSection("AppSettings"));
                
                services.AddSingleton(new LoggerFactory()
                    .AddConsole()
                    .AddDebug(LogLevel.Trace));
                services.AddLogging(); 

                // Dependency injection bindings for application
                services.BindCommonServicesAsSingleton();
                services.BindRepositoriesAsSingleton();
                services.BindSeeders();

                IServiceProvider serviceProvider = services
                    .BuildServiceProvider();

                serviceProvider
                    .GetService<ILoggerFactory>()
                    .AddConsole(LogLevel.Debug);

                return serviceProvider;
        }
    }
}