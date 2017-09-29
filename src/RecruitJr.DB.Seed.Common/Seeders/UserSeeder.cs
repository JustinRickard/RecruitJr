using RecruitJr.Core.Classes;
using RecruitJr.Core.Interfaces.Helpers;
using RecruitJr.Core.Interfaces.Repositories;
using RecruitJr.DB.Seed.Common;
using RecruitJr.DB.Seed.Common.Interfaces;
using Microsoft.Extensions.Logging;

namespace RecruitJr.DB.Seed.Common.Seeders
{
    public class UserSeeder : SeederBase, ISeeder
    {
        IUserRepository userRepository;

        public UserSeeder(
            IUserRepository userRepository,
            ILoggerFactory loggerFactory
        ): base(loggerFactory) {
            this.userRepository = userRepository;
        }

        public Result Seed()
        {
            logger.LogDebug("Seeding user data...");

            // To do: seed users to database

            logger.LogDebug("Seeding user data complete.");
            return Result.Succeed();
        }
    }
}