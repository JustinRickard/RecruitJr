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
    public class ProjectSeeder : SeederBase, ISeeder
    {
        public ProjectSeeder(
            SeederDependencies dependencies
        ) : base(dependencies)
        {
            this.fileName = "Projects.json";
        }

        public async Task<Result> Seed()
        {
            dependencies.logger.LogDebug("Seeding project data...");

            var projects = DeserializeFile<IEnumerable<SeedProjectAddDto>>();

            foreach(var projectDto in projects) 
            {
                var maybeProject = await dependencies.projectRepository.GetByCode(projectDto.Code);
                
                if (maybeProject.HasNoValue) {
                    // TODO: Get workflow by code
                    await dependencies.projectRepository.Add(projectDto.ToModel("TempWorkflowId"));
                }
            }

            dependencies.logger.LogDebug("Seeding project data complete.");
            return Result.Succeed();
        }
    }
}