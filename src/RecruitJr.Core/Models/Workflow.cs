using System.Collections.Generic;
using RecruitJr.Core.Classes;
using RecruitJr.Core.Interfaces.Common;

namespace RecruitJr.Core.Models
{
    public class Workflow : DbRecordBaseWithNameAndCode
    {
        public string Description { get; set; }
        public IEnumerable<WorkflowStage> WorkflowStages { get; set; }
    }
}