using RecruitJr.Core.Enums.WorkflowSteps;

namespace RecruitJr.Core.Interfaces.Models
{
    public interface IWorkflowStepItem
    {
        WorkflowStepItemType ItemType { get; }
    }
}