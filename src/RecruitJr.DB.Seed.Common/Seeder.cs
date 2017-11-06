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
        ProjectSeeder projectSeeder;
        WorkflowStepItemSeeder workflowStepItemSeeder;

        public Seeder(
            SeederDependencies dependencies,
            UserSeeder userSeeder,
            ClientSeeder clientSeeder,
            ProjectSeeder projectSeeder,
            WorkflowStepItemSeeder workflowStepItemSeeder
        ): base(dependencies) {      
            this.userSeeder = userSeeder;
            this.clientSeeder = clientSeeder;
            this.projectSeeder = projectSeeder;
            this.workflowStepItemSeeder = workflowStepItemSeeder;
        }        

        public void Run() {

            dependencies.logger.LogDebug("Seeding data to database...");

            clientSeeder.Seed().Wait();
            userSeeder.Seed().Wait();
            workflowStepItemSeeder.Seed().Wait();
            // workflowStepSeeder.Seed().Wait();
            // workflowSeeder.Seed().Wait();
            projectSeeder.Seed().Wait();

            dependencies.logger.LogDebug("Seeding complete");
        }
    }
}