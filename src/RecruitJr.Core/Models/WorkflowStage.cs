using System.Collections.Generic;
using RecruitJr.Core.Classes;
using RecruitJr.Core.Dto;

namespace RecruitJr.Core.Models
{
    public class WorkflowStage : DbRecordBaseWithNameAndCode
    {        
        public IEnumerable<WorkflowStepData> WorkflowStepData { get; set; }
    }
}