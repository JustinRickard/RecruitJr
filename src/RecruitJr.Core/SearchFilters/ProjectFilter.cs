using System;

namespace RecruitJr.Core.SearchFilters
{
    public class ProjectFilter
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string WorkflowId { get; set; }
        public DateTimeOffset StartTimeBefore { get; set; }
        public DateTimeOffset StartTimeAfter { get; set; }
        public DateTimeOffset EndTimeBefore { get; set; }
        public DateTimeOffset EndTimeAfter { get; set; }

        
    }
}