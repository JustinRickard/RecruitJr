using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Abstractions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Configuration;
using RecruitJr.DAL.MongoDB.Repositories;
using RecruitJr.Core.Interfaces.Repositories;
using RecruitJr.Core.Interfaces.Helpers;
using RecruitJr.Core.Models;
using RecruitJr.Core.Classes;
using RecruitJr.Core.Helpers;
using RecruitJr.DB.Seed.Common;
using RecruitJr.DB.Seed.MongoDB.Helpers;

namespace DB.Seed.MongoDB
{
    public class Program
    {
        public static IConfigurationRoot Configuration { get; set; }
        public static IServiceProvider ServiceProvider {get; set; }

        public static void Main(string[] args)
        {
            Configuration = ConfigurationHelper.BuildConfig();
            ServiceProvider = ConfigurationHelper.BuildServiceProvider(Configuration);            

            var logger = ServiceProvider.GetService<ILoggerFactory>()
                .CreateLogger<Program>();
            logger.LogDebug("Start seeding data to MongoDB...");
            
            ServiceProvider.GetService<Seeder>().Run();

            /*
            var logger = ServiceProvider.GetService<ILoggerFactory>()
                .CreateLogger<Seeder>();
            logger.LogTrace("Starting DB seeding...");

            var userRepository = ServiceProvider.GetService<IUserRepository>();
            var jsonHelper = ServiceProvider.GetService<IJsonHelper>();

            logger.LogDebug("ConnectionString:");
            logger.LogDebug(Configuration["AppSettings:ConnectionString"]);            


            logger.LogDebug("Adding users...");

            var user = new User(
                "Client 1",
                "User2",
                "Two",
                "userone@example.org",
                "UserTwo"
            );

            var maybeUserTask = userRepository.Add(user);
            var maybeUser = maybeUserTask.GetAwaiter().GetResult();

            if (maybeUser.HasValue) {
                logger.LogDebug("User added.");
            } else {
                logger.LogDebug("User not added.");
            }

            logger.LogDebug("Finished seeding");
             */

        }
    }
}
