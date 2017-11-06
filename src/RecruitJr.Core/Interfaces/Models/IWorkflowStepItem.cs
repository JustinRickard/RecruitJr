using RecruitJr.Core.Enums.WorkflowSteps;
using RecruitJr.Core.Interfaces.Common;

namespace RecruitJr.Core.Interfaces.Models
{
    public interface IWorkflowStepItem : IHasCode
    {
        WorkflowStepItemType ItemType { get; }
    }
}