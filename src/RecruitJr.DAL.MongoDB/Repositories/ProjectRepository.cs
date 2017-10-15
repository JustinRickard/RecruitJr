using RecruitJr.Core.Models;
using RecruitJr.Core.SearchFilters;
using RecruitJr.Core.Interfaces.Repositories;
using RecruitJr.Core.Classes;
using System.Collections.Generic;
using System.Threading.Tasks;
using RecruitJr.DAL.MongoDB.Models;
using MongoDB.Driver;
using Microsoft.Extensions.Options;
using MongoDB.Driver.Linq;
using RecruitJr.Core.ExtensionMethods;
using MongoDB.Bson;
using RecruitJr.DAL.MongoDB.DtoConversions;

namespace RecruitJr.DAL.MongoDB.Repositories
{
    public class ProjectRepository : RepositoryBase, IProjectRepository
    {
        public ProjectRepository(
            IOptions<AppSettings> appSettings
        ): base (appSettings) 
        {
        }

        public async Task<Maybe<Project>> Add(Project project)
        {
            var addedProject = await Add<DbProject>(project.ToDb());
            return MaybeProject(addedProject);
        }

        public async Task Delete(string id)
        {
            await Delete<DbProject>(id);
        }

        public async Task<IEnumerable<Project>> Get(ProjectFilter filter)
        {
            using (var ctx = GetContext()) {
                var projects = await Filter(ctx, filter).ToListAsync();
                return projects.ToModel();
            }
        }

        public async Task<IEnumerable<Project>> GetAll()
        {
            var dbClients = await GetAllNotDeleted<DbProject>();
            return dbClients.ToModel();
        }

        public async Task<Maybe<Project>> GetByCode(string code)
        {
            var project = await GetOneByCode<DbProject>(code);
            return MaybeProject(project);
        }

        public async Task<Maybe<Project>> GetById(string id)
        {
            var project = await GetOne<DbProject>(id);
                return MaybeProject(project);
        }

        public async Task Obliterate(string id)
        {
            await Obliterate<DbProject>(id);
        }

        public async Task<Maybe<Project>> Update(Project project)
        {
            var update = Builders<DbProject>.Update
                .Set(x => x.Code, project.Code)                
                .Set(x => x.Name, project.Name)
                .Set(x => x.StartTime, project.StartTime)
                .Set(x => x.EndTime, project.EndTime)
                .Set(x => x.Settings, project.Settings);

            return await UpdateAndReturn<DbClient>(project.Id, update); 
        }

        // HELPER METHODS

        private Maybe<Project> MaybeProject(Maybe<DbProject> Project) 
        {
            return Project.HasValue
                    ? MaybeProject(Project.Value)
                    : Maybe<Project>.Fail;
        }

        private Maybe<Project> MaybeProject(DbProject project) 
        {
            return project != null 
                    ? new Maybe<Project>(project.ToModel())
                    : Maybe<Project>.Fail;
        }

        private async Task<Maybe<Project>> UpdateAndReturn<TEntity>(string id, UpdateDefinition<DbProject> update)
        {
            var updatedProject = await Update<DbProject>(id, update);
            return MaybeProject(updatedProject);
        }

        private IMongoQueryable<DbProject> Filter (RsMongoContext ctx, ProjectFilter filter) 
        {
            var query = ctx.Projects.AsQueryable();

            if (filter.Code.NotEmpty()) {
                query = query.Where(x => x.Code.CaseInsensitiveEquals(filter.Code));
            }

            if (filter.Name.NotEmpty()) {
                query = query.Where(x => x.Name.CaseInsensitiveEquals(filter.Name));
            }

            if (filter.WorkflowId.NotEmpty()) {
                query = query.Where(x => x.WorkflowId == ObjectId.Parse(filter.WorkflowId));
            }

            if (filter.StartTimeBefore != null) {
                query = query.Where(x => x.StartTime < filter.StartTimeBefore);
            }

            if (filter.StartTimeAfter != null) {
                query = query.Where(x => x.StartTime > filter.StartTimeAfter);
            }

            if (filter.EndTimeBefore != null) {
                query = query.Where(x => x.EndTime < filter.EndTimeBefore);
            }

            if (filter.EndTimeBefore != null) {
                query = query.Where(x => x.EndTime > filter.EndTimeBefore);
            }

            return query;
        }
    }
}