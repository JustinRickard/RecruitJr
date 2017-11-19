using System.Collections.Generic;
using System.Linq;
using RecruitJr.Core.Dto;
using RecruitJr.Core.Models;
using RecruitJr.Core.Models.WorkflowStepItems;

namespace RecruitJr.Core.ExtensionMethods
{
    public static class WorkflowStepItemExtension
    {
        public static SimpleQuestion ToModel(this SeedSimpleQuestionAddDto dto, Competency competency) {
            return new SimpleQuestion {
                Code = dto.Code,
                Competency = competency,                
                Question = new Question {
                    Text = dto.Text,
                    Options = dto.Options
                    
                }
            };
        }

        public static TextScenario ToModel(this SeedTextScenarioAddDto dto, Competency competency) {
            return new TextScenario {
                Code = dto.Code,
                Competency = competency,
                ScenarioText = dto.ScenarioText,
                Questions = dto.Questions.ToModel(),
            
            };
        }

        public static Question ToModel(this SeedQuestion seed) {
            return new Question {
                Code = seed.Code,
                Text = seed.Text,
                Options = seed.Options         
            };
        }

        public static IEnumerable<Question> ToModel(this IEnumerable<SeedQuestion> seedQuestions) {
            return seedQuestions.Select(x => x.ToModel()).ToList();
        }

    }
}