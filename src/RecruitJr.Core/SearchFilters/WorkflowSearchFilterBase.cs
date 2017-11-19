using RecruitJr.Core.Interfaces.Common;

namespace RecruitJr.Core.SearchFilters
{
    public class WorkflowSearchFilterBase : IHasCode, IHasName
    {
        public string CultureCode { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
    }
}