using RecruitJr.Core.Enums.WorkflowSteps;
using RecruitJr.Core.Interfaces.Models;

namespace RecruitJr.Core.Models.WorkflowStepItems
{
    public class SimpleQuestion : WorkflowStepItemBase, IWorkflowStepItem
    {
        public WorkflowStepItemType ItemType { get => WorkflowStepItemType.SimpleQuestion; }

        public Question Question { get; set; }
    }
}