using System.Collections.Generic;
using RecruitJr.Core.Interfaces.Models;

namespace RecruitJr.Core.Models
{
    public class WorkflowStep
    {
        public string Code { get; set; }
        public IEnumerable<IWorkflowStepItem> Items { get; set; }
    }
}