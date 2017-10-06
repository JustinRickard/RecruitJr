using RecruitJr.Core.Classes;
using RecruitJr.Core.Dto;
using RecruitJr.Core.ExtensionMethods;
using RecruitJr.Core.Interfaces.Helpers;
using RecruitJr.Core.Interfaces.Repositories;
using RecruitJr.Core.Models;
using RecruitJr.Core.Security;
using RecruitJr.DB.Seed.Common;
using RecruitJr.DB.Seed.Common.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace RecruitJr.DB.Seed.Common.Seeders
{
    public class UserSeeder : SeederBase, ISeeder
    {
        IClientRepository clientRepository;
        UserManager<User> userManager;

        public UserSeeder(
            IClientRepository clientRepository,
            ILoggerFactory loggerFactory,
            UserManager<User> userManager
        ): base(loggerFactory) {
            this.userManager = userManager;
            this.clientRepository = clientRepository;
        }

        public async Task<Result> Seed()
        {
            logger.LogDebug("Seeding user data...");

            var users = new List<SeedUserAddDto>();
            // TODO: Read users from JSON.

            foreach(var userDto in users) 
            {
                var maybeClient = await clientRepository.GetByCode(userDto.ClientCode);
                if (maybeClient.HasNoValue) {
                    throw new Exception(string.Format("Client not found with code: {0}", userDto.ClientCode));
                }

                User user = userDto.ToModel(maybeClient.Value.Id);
                await userManager.CreateAsync(user, userDto.Password);
            }

            logger.LogDebug("Seeding user data complete.");
            return Result.Succeed();
        }
    }
}