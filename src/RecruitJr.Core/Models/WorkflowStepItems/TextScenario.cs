using System.Collections.Generic;
using RecruitJr.Core.Enums.WorkflowSteps;

namespace RecruitJr.Core.Models.WorkflowStepItems
{
    public class TextScenario : ModelWithCodeBase
    {
        public WorkflowStepItemType ItemType { get => WorkflowStepItemType.TextScenario; }

        public string BackgroundText { get; set; }
        public string ScenarioText { get; set; }
        public IEnumerable<Question> Questions { get; set; }
    }
}