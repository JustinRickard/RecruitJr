using System.Collections.Generic;
using RecruitJr.Core.Enums.WorkflowSteps;
using RecruitJr.Core.Interfaces.Models;
using RecruitJr.Core.Models.WorkflowStepItems;

namespace RecruitJr.Core.Dto
{
    public class SeedTextScenarioAddDto : SeedWorkflowStepItemBase
    {
        
        public string ScenarioText { get; set; }

        public IEnumerable<SeedQuestion> Questions { get; set; }
    }
}