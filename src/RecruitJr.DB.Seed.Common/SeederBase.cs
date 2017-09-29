using Microsoft.Extensions.Logging;

namespace RecruitJr.DB.Seed.Common
{
    public class SeederBase
    {
        public ILogger<Seeder> logger;

        public SeederBase(ILoggerFactory loggerFactory) {
            this.logger = loggerFactory.CreateLogger<Seeder>();
        }
    }
}