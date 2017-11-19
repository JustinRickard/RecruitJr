using RecruitJr.Core.Enums.WorkflowSteps;
using RecruitJr.Core.Interfaces.Common;

namespace RecruitJr.Core.SearchFilters
{
    public class WorkflowStepItemFilter : WorkflowSearchFilterBase
    {
        public WorkflowStepItemType ItemType { get; set; }
    }
}