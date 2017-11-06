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
using Microsoft.Extensions.Options;

namespace RecruitJr.DB.Seed.Common.Seeders
{
    public class UserSeeder : SeederBase, ISeeder
    {
        private static string fileName = "Users.json";

        public UserSeeder(
            SeederDependencies dependencies
        ): base(dependencies) {
        }        

        public async Task<Result> Seed()
        {
            dependencies.logger.LogDebug("Seeding user data...");

            var users = DeserializeFile<IEnumerable<SeedUserAddDto>>(fileName);

            foreach(var userDto in users) 
            {
                var maybeClient = await dependencies.clientRepository.GetByCode(userDto.ClientCode);
                if (maybeClient.HasNoValue) {
                    throw new Exception(string.Format("Client not found with code: {0}", userDto.ClientCode));
                }

                User user = userDto.ToModel(maybeClient.Value.Id);
                await dependencies.userManager.CreateAsync(user, userDto.Password);
            }

            dependencies.logger.LogDebug("Seeding user data complete.");
            return Result.Succeed();
        }

        Task<Result> ISeeder.Seed()
        {
            throw new NotImplementedException();
        }
    }
}