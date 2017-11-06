using System;
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
        private static string fileName = "Projects.json";

        public ProjectSeeder(
            SeederDependencies dependencies
        ) : base(dependencies)
        {
        }

        public async Task<Result> Seed()
        {
            dependencies.logger.LogDebug("Seeding project data...");

            var projects = DeserializeFile<IEnumerable<SeedProjectAddDto>>(fileName);

            foreach(var projectDto in projects) 
            {
                var maybeProject = await dependencies.projectRepository.GetByCode(projectDto.Code);
                
                if (maybeProject.HasNoValue) {
                    
                    string workflowCode = projectDto.WorkflowCode;
                    var maybeWorkflow = await dependencies.workflowRepository.GetByCode(projectDto.WorkflowCode);
                    if (maybeWorkflow.HasNoValue) { 
                        throw new Exception (string.Format("Seed projects: could not find workflow with code {0}", workflowCode));
                    }
                    await dependencies.projectRepository.Add(projectDto.ToModel(maybeWorkflow.Value.Id));
                }
            }

            dependencies.logger.LogDebug("Seeding project data complete.");
            return Result.Succeed();
        }
    }
}