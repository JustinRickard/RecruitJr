using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RecruitJr.Core.Classes;
using RecruitJr.Core.Interfaces.Helpers;
using RecruitJr.Core.Interfaces.Repositories;
using RecruitJr.Core.Models;

namespace RecruitJr.DB.Seed.Common
{
    public class SeederDependencies
    {
            public IClientRepository clientRepository;
            public IUserRepository userRepository;
            public IProjectRepository projectRepository;
            public IFileReader fileReader;
            public IJsonHelper jsonHelper;
            public AppSettings appSettings;
            public ILogger logger;
            public UserManager<User> userManager;

        public SeederDependencies(
            IClientRepository clientRepository,
            IUserRepository userRepository,
            IProjectRepository projectRepository,
            IFileReader fileReader,
            IJsonHelper jsonHelper,
            IOptions<AppSettings> appSettings,
            ILoggerFactory loggerFactory,            
            UserManager<User> userManager
        ) {
            this.clientRepository = clientRepository;
            this.userRepository = userRepository;
            this.projectRepository = projectRepository;
            this.fileReader = fileReader;
            this.jsonHelper = jsonHelper;
            this.appSettings = appSettings.Value;
            this.logger = loggerFactory.CreateLogger<Seeder>();;
            this.userManager = userManager;
        }
    }
}