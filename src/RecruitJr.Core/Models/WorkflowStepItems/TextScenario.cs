using System.Collections.Generic;
using RecruitJr.Core.Enums.WorkflowSteps;
using RecruitJr.Core.Interfaces.Common;
using RecruitJr.Core.Interfaces.Models;

namespace RecruitJr.Core.Models.WorkflowStepItems
{
    public class TextScenario : WorkflowStepItemBase, IWorkflowStepItem
    {
        public WorkflowStepItemType ItemType { get => WorkflowStepItemType.TextScenario; }

        public string BackgroundText { get; set; }
        public string ScenarioText { get; set; }
        public IEnumerable<Question> Questions { get; set; }

    }
}