using RecruitJr.Core.Interfaces.Helpers;
using RecruitJr.Core.Interfaces.Repositories;
using RecruitJr.DB.Seed.Common.Seeders;
using RecruitJr.DB.Seed.Common.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RecruitJr.Core.Classes;

namespace RecruitJr.DB.Seed.Common
{
    public class Seeder : SeederBase
    {
        UserSeeder userSeeder;
        ClientSeeder clientSeeder;

        public Seeder(
            ILoggerFactory loggerFactory,
            IOptions<AppSettings> appSettings,
            IFileReader fileReader,
            IJsonHelper jsonHelper,
            UserSeeder userSeeder,
            ClientSeeder clientSeeder
        ): base(appSettings, fileReader, jsonHelper, loggerFactory) {
            this.userSeeder = userSeeder;
            this.clientSeeder = clientSeeder;
        }

        public void Run() {

            logger.LogDebug("Seeding data to database...");

            clientSeeder.Seed().Wait();
            userSeeder.Seed().Wait();

            logger.LogDebug("Seeding complete");
        }
    }
}