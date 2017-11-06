using System.Collections.Generic;
using RecruitJr.Core.Enums.WorkflowSteps;
using RecruitJr.Core.Interfaces.Models;
using RecruitJr.Core.Models.WorkflowStepItems;

namespace RecruitJr.Core.Dto
{
    public class SeedSimpleQuestionAddDto : SeedWorkflowStepItemBase
    {
        public string Text { get; set; }
        public IEnumerable<QuestionOption> Options { get; set; }

    }
}