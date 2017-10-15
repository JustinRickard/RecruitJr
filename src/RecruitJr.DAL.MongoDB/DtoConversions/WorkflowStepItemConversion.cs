using System;
using System.Collections.Generic;
using RecruitJr.Core.Classes;
using RecruitJr.Core.Enums.WorkflowSteps;
using RecruitJr.Core.Interfaces.Helpers;
using RecruitJr.Core.Interfaces.Models;
using RecruitJr.Core.Models.WorkflowStepItems;
using RecruitJr.DAL.MongoDB.Models;

namespace RecruitJr.DAL.MongoDB.DtoConversions
{
    public static class WorkflowStepItemConversion
    {
        public static IWorkflowStepItem ToModel(this DbWorkflowStepItem item, IJsonHelper jsonHelper) {
            switch (item.ItemType) {
                case WorkflowStepItemType.SimpleQuestion:
                    return GetSimpleQuestion(item, jsonHelper);
                case WorkflowStepItemType.TextScenario:
                    return GetTextScenario(item, jsonHelper);                    
                default:
                    throw new Exception(
                        string.Format("Workflow step item {0} does not have a valid type. Type: {1}", 
                            item.Code, item.ItemType));
            }
        }

        private static SimpleQuestion GetSimpleQuestion(DbWorkflowStepItem item, IJsonHelper jsonHelper) {
            Result<Question> result = jsonHelper.Deserialize<Question> (item.Content);
            if (result.IsFailure) {
                throw new Exception(string.Format("Could not deserialize SimpleQuestion workflow step item content to Question. Code: {0}", item.Code));
            }

            return new SimpleQuestion {
                Id = item.Id,                         
                Code = item.Code,
                CultureCode = item.CultureCode,
                Question = result.Value,                        
                LastModified = item.LastModified,
                DateCreated = item.DateCreated
            };
        }

        private static TextScenario GetTextScenario(DbWorkflowStepItem item, IJsonHelper jsonHelper) {
            Result<IEnumerable<Question>> result = jsonHelper.Deserialize<IEnumerable<Question>> (item.Content);
            if (result.IsFailure) {
                throw new Exception(string.Format("Could not deserialize TextScenario workflow step item content to IEnumerable<Question>. Code: {0}", item.Code));
            }

            return new TextScenario {
                Id = item.Id,
                Code = item.Code,
                CultureCode = item.CultureCode,
                Questions = result.Value,
                LastModified = item.LastModified,
                DateCreated = item.DateCreated
            };
        }
    }
}