using RecruitJr.Core.Enums.WorkflowSteps;
using RecruitJr.Core.Interfaces.Models;

namespace RecruitJr.Core.Dto
{
    public class SeedWorkflowStepItemBase : IWorkflowStepItem
    {
        public WorkflowStepItemType ItemType { get; set; }
        public string Code { get; set; }
        public string CompetencyCode { get; set; }
    }
}