using RecruitJr.Core.Interfaces.Common;

namespace RecruitJr.Core.SearchFilters
{
    public class WorkflowStepFilter : IHasCode, IHasName
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}