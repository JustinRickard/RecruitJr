using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RecruitJr.Core.Classes;
using RecruitJr.Core.Dto;
using RecruitJr.Core.ExtensionMethods;
using RecruitJr.Core.Interfaces.Helpers;
using RecruitJr.Core.Interfaces.Repositories;
using RecruitJr.DB.Seed.Common.Interfaces;

namespace RecruitJr.DB.Seed.Common.Seeders
{
    public class ClientSeeder : SeederBase, ISeeder
    {
        private static string fileName = "Clients.json";

        public ClientSeeder(
            SeederDependencies dependencies
        ) : base(dependencies)
        {
        }

        public async Task<Result> Seed()
        {
            dependencies.logger.LogDebug("Seeding client data...");

            var clients = DeserializeFile<IEnumerable<SeedClientAddDto>>(fileName);

            foreach(var clientDto in clients) 
            {
                var maybeClient = await dependencies.clientRepository.GetByCode(clientDto.Code);
                
                if (maybeClient.HasNoValue) {

                    string parentId = null;
                    if (clientDto.ParentCode.NotEmpty()) {
                        var parent = await dependencies.clientRepository.GetByCode(clientDto.ParentCode);
                        if (parent.HasValue) {
                            parentId = parent.Value.Id;
                        }
                    }

                    await dependencies.clientRepository.Add(clientDto.ToModel(parentId));
                }
            }

            dependencies.logger.LogDebug("Seeding client data complete.");
            return Result.Succeed();
        }
    }
}