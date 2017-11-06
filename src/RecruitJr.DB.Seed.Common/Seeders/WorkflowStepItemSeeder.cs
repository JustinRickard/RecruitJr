using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using RecruitJr.Core.Classes;
using RecruitJr.Core.Dto;
using RecruitJr.Core.Enums.WorkflowSteps;
using RecruitJr.Core.ExtensionMethods;
using RecruitJr.Core.Interfaces.Models;
using RecruitJr.DB.Seed.Common.Interfaces;

namespace RecruitJr.DB.Seed.Common.Seeders
{
    public class WorkflowStepItemSeeder : SeederBase, ISeeder
    {
        private Dictionary<WorkflowStepItemType, string> filePaths;

        public WorkflowStepItemSeeder(
            SeederDependencies dependencies
        ) : base(dependencies)
        {
            this.filePaths = new Dictionary<WorkflowStepItemType, string> {
                { WorkflowStepItemType.SimpleQuestion, "WorkflowStepItems/SimpleQuestions.json" },
                { WorkflowStepItemType.TextScenario, "WorkflowStepItems/TextScenarios.json" }
            } ;
        }

        public async Task<Result> Seed()
        {
            dependencies.logger.LogDebug("Seeding project data...");

            await SeedSimpleQuestions();
            await SeedTextScenarios();

            
            dependencies.logger.LogDebug("Seeding project data complete.");
            return Result.Succeed();
        }

        private async Task<Result> SeedSimpleQuestions() {
            var questions = DeserializeFile<IEnumerable<SeedSimpleQuestionAddDto>>(filePaths[WorkflowStepItemType.SimpleQuestion]);
            foreach (var q in questions) {
                bool canAdd = await IsValid(q);
                if (!canAdd) {
                    dependencies.logger.LogDebug(string.Format("Cannot add question: {0}", q.Code));
                } else {
                    var competencyId = ""; // TODO: Get from competency repository
                    await dependencies.workflowStepItemRepository.Add(q.ToModel(competencyId));
                }                
            }

            return Result.Succeed();
        }

        private async Task<Result> SeedTextScenarios() {
            var questions = DeserializeFile<IEnumerable<SeedTextScenarioAddDto>>(filePaths[WorkflowStepItemType.TextScenario]);
            foreach (var q in questions) {
                bool canAdd = await IsValid(q);
                if (!canAdd) {
                    dependencies.logger.LogDebug(string.Format("Cannot add question: {0}", q.Code));
                } else {
                    var competencyId = ""; // TODO: Get from competency repository
                    await dependencies.workflowStepItemRepository.Add(q.ToModel(competencyId));
                }                
            }

            return Result.Succeed();
        }

        private async Task<bool> IsValid(IWorkflowStepItem item) {
            var dbRecord = await dependencies.workflowStepItemRepository.GetByCode(item.Code);
            // TODO: Add Competency repo
            // var competencyRecord = await dependencies.competencyRepository.GetByCode(item.CompetencyCode);

            return dbRecord.HasValue;
        }
    }
}