namespace RecruitJr.Core.SearchFilters
{
    public class WorkflowStageFilter : WorkflowSearchFilterBase
    {
        public int MinimumItems { get; set; }
        public int MaximumItems { get; set; }
    }
}