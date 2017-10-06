using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using RecruitJr.Core.Classes;
using RecruitJr.Core.Dto;
using RecruitJr.Core.ExtensionMethods;
using RecruitJr.Core.Interfaces.Repositories;
using RecruitJr.DB.Seed.Common.Interfaces;

namespace RecruitJr.DB.Seed.Common.Seeders
{
    public class ClientSeeder : SeederBase, ISeeder
    {
        IClientRepository clientRepository;

        public ClientSeeder(
            IClientRepository clientRepository,
            ILoggerFactory loggerFactory
        ) : base(loggerFactory)
        {
            this.clientRepository = clientRepository;
        }

        public async Task<Result> Seed()
        {
            var clients = new List<SeedClientAddDto>();
            // TODO: Read users from JSON.

            foreach(var clientDto in clients) 
            {
                var maybeClient = await clientRepository.GetByCode(clientDto.Code);
                
                if (maybeClient.HasNoValue) {

                    string parentId = string.Empty;
                    if (clientDto.ParentCode.NotEmpty()) {
                        var parent = await clientRepository.GetByCode(clientDto.ParentCode);
                        if (parent.HasValue) {
                            parentId = parent.Value.Id;
                        }
                    }

                    await clientRepository.Add(clientDto.ToModel(parentId));
                }
            }

            logger.LogDebug("Seeding user data complete.");
            return Result.Succeed();
        }
    }
}