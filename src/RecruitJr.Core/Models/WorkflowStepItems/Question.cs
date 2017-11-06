using System.Collections.Generic;

namespace RecruitJr.Core.Models.WorkflowStepItems
{
    public class Question : WorkflowStepItemBase
    {        
        public string Text { get; set; }

        public IEnumerable<QuestionOption> Options { get; set; }
    }
}