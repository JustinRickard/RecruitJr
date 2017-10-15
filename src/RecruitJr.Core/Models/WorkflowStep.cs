using System.Collections.Generic;
using RecruitJr.Core.Classes;
using RecruitJr.Core.Interfaces.Common;
using RecruitJr.Core.Interfaces.Models;

namespace RecruitJr.Core.Models
{
    public class WorkflowStep : DbRecordBase, IHasCode, IHasName
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public IEnumerable<IWorkflowStepItem> Items { get; set; }
        
    }
}