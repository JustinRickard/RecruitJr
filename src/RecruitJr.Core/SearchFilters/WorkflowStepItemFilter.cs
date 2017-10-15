using RecruitJr.Core.Enums.WorkflowSteps;
using RecruitJr.Core.Interfaces.Common;

namespace RecruitJr.Core.SearchFilters
{
    public class WorkflowStepItemFilter : IHasCode, IHasName
    {        
        public string Code { get; set; }
        public string Name { get; set; }
        public WorkflowStepItemType ItemType { get; set; }
    }
}