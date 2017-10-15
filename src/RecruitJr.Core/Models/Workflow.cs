using System.Collections.Generic;
using RecruitJr.Core.Classes;

namespace RecruitJr.Core.Models
{
    public class Workflow : DbRecordBase
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<WorkflowStep> WorkflowSteps { get; set; }
    }
}