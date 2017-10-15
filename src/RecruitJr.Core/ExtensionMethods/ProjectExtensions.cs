using RecruitJr.Core.Dto;
using RecruitJr.Core.Models;

namespace RecruitJr.Core.ExtensionMethods
{
    public static class ProjectExtensions
    {
        public static Project ToModel(this SeedProjectAddDto dto, string workflowId) {
            return new Project {
                Code = dto.Code,
                Name = dto.Name,
                WorkflowId = workflowId,
                StartTime = dto.StartTime,
                EndTime = dto.EndTime,
                Settings = dto.Settings
            };
        }
    }
}