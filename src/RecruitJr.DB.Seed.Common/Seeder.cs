using RecruitJr.Core.Interfaces.Helpers;
using RecruitJr.Core.Interfaces.Repositories;
using RecruitJr.DB.Seed.Common.Seeders;
using RecruitJr.DB.Seed.Common.Interfaces;
using Microsoft.Extensions.Logging;

namespace RecruitJr.DB.Seed.Common
{
    public class Seeder : SeederBase
    {
        UserSeeder userSeeder;

        public Seeder(
            ILoggerFactory loggerFactory,
            UserSeeder userSeeder
        ): base(loggerFactory) {
            this.userSeeder = userSeeder;
        }

        public void Run() {

            logger.LogDebug("Seeding data to database...");

            userSeeder.Seed();

            logger.LogDebug("Seeding complete");
        }
    }
}