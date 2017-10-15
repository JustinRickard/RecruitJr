using System.Collections.Generic;

namespace RecruitJr.Core.Models.WorkflowStepItems
{
    public class Question : ModelWithCodeBase
    {
        public string QuestionText { get; set; }

        public IEnumerable<QuestionOption> Options { get; set; }
    }
}