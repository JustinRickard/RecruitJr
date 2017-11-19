using System.Collections.Generic;
using RecruitJr.Core.Classes;
using RecruitJr.Core.Interfaces.Common;
using RecruitJr.Core.Interfaces.Models;

namespace RecruitJr.Core.Models
{
    public class WorkflowStep : DbRecordBaseWithNameAndCode
    {
        public IEnumerable<IWorkflowStepItem> Items { get; set; }
        
    }
}