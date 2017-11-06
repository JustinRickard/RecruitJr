using System.Collections.Generic;
using System.Linq;
using RecruitJr.Core.Dto;
using RecruitJr.Core.Models.WorkflowStepItems;

namespace RecruitJr.Core.ExtensionMethods
{
    public static class WorkflowStepItemExtension
    {
        public static SimpleQuestion ToModel(this SeedSimpleQuestionAddDto dto, string competencyId) {
            return new SimpleQuestion {
                Code = dto.Code,                
                Question = new Question {
                    Text = dto.Text,
                    Options = dto.Options,
                    CompetencyId = competencyId
                }
            };
        }

        public static TextScenario ToModel(this SeedTextScenarioAddDto dto, string competencyId) {
            return new TextScenario {
                Code = dto.Code,
                ScenarioText = dto.ScenarioText,
                CompetencyId = competencyId,
                Questions = dto.Questions.ToModel(competencyId),
            
            };
        }

        public static Question ToModel(this SeedQuestion seed, string competencyId) {
            return new Question {
                Code = seed.Code,
                CompetencyId = competencyId,
                Text = seed.Text,
                Options = seed.Options         
            };
        }

        public static IEnumerable<Question> ToModel(this IEnumerable<SeedQuestion> seedQuestions, string competencyId) {
            return seedQuestions.Select(x => x.ToModel(competencyId)).ToList();
        }

    }
}