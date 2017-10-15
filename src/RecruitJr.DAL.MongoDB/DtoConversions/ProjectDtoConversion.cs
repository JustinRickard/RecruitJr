using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using RecruitJr.Core.Models;
using RecruitJr.DAL.MongoDB.Models;

namespace RecruitJr.DAL.MongoDB.DtoConversions
{
    public static class ProjectDtoConversion
    {
        public static Project ToModel(this DbProject dbProject) {
            return new Project {
                Id = dbProject.Id,
                Code = dbProject.Code,
                Name = dbProject.Name,
                WorkflowId = dbProject.WorkflowId.ToString(),
                StartTime = dbProject.StartTime,
                EndTime = dbProject.EndTime,
                Settings = dbProject.Settings
            };
        }

        public static Project ToModel(this DbProject dbProject, DbWorkflow dbWorkflow) {
            var model = dbProject.ToModel();
            // TODO: Uncomment after workflow extensions have been written.
            // model.Workflow = dbWorkflow.ToModel();
            return model;
        }

        public static DbProject ToDb(this Project project) {
            return new DbProject {
                Id = project.Id,
                Code = project.Code,
                Name = project.Name,
                WorkflowId = ObjectId.Parse(project.WorkflowId),
                StartTime = project.StartTime,
                EndTime = project.EndTime,
                Settings = project.Settings
            };
        }

        public static IEnumerable<Project> ToModel(this IEnumerable<DbProject> dbProjects) {
            return dbProjects != null 
                ? dbProjects.Select(project => project.ToModel())
                : new List<Project>();
        }

        public static IEnumerable<DbProject> ToDb(this IEnumerable<Project> projects) {
            return projects != null
                ? projects.Select(project => project.ToDb())
                : new List<DbProject>();
        }
    }
}