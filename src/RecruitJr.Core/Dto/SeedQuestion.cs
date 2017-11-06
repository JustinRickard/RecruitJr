using System.Collections.Generic;
using RecruitJr.Core.Models;
using RecruitJr.Core.Models.WorkflowStepItems;

namespace RecruitJr.Core.Dto
{
    public class SeedQuestion : ModelWithCodeBase
    {
        public string CompetencyCode { get; set; }
        public string Text { get; set; }
        public IEnumerable<QuestionOption> Options { get; set; }
    }
}