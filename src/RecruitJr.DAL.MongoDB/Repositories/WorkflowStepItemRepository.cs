using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using RecruitJr.Core.Classes;
using RecruitJr.Core.ExtensionMethods;
using RecruitJr.Core.Interfaces.Helpers;
using RecruitJr.Core.Interfaces.Models;
using RecruitJr.Core.Interfaces.Repositories;
using RecruitJr.Core.SearchFilters;
using RecruitJr.DAL.MongoDB.DtoConversions;
using RecruitJr.DAL.MongoDB.Models;

namespace RecruitJr.DAL.MongoDB.Repositories
{
    public class WorkflowStepItemRepository : RepositoryBase, IWorkflowStepItemRepository
    {
        private IJsonHelper jsonHelper;

        public WorkflowStepItemRepository (
            IOptions<AppSettings> appSettings,
            IJsonHelper jsonHelper
        ) : base (appSettings) 
        {
            this.jsonHelper = jsonHelper;
        }

        public Task<Maybe<IWorkflowStepItem>> Add(IWorkflowStepItem item)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<IWorkflowStepItem>> Get(WorkflowStepItemFilter filter)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<IWorkflowStepItem>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<Maybe<IWorkflowStepItem>> GetById(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Maybe<IWorkflowStepItem>> GetByCode(string code)
        {
            throw new System.NotImplementedException();
        }

        public Task Obliterate(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Maybe<IWorkflowStepItem>> Update(IWorkflowStepItem user)
        {
            throw new System.NotImplementedException();
        }


        // HELPER METHODS

        private Maybe<IWorkflowStepItem> MaybeWorkflowStepItem(Maybe<DbWorkflowStepItem> workflowStepItem) 
        {
            return workflowStepItem.HasValue
                    ? MaybeWorkflowStepItem(workflowStepItem.Value)
                    : Maybe<IWorkflowStepItem>.Fail;
        }

        private Maybe<IWorkflowStepItem> MaybeWorkflowStepItem(DbWorkflowStepItem workflowStepItem) 
        {
            return workflowStepItem != null 
                    ? new Maybe<IWorkflowStepItem>(workflowStepItem.ToModel(jsonHelper))
                    : Maybe<IWorkflowStepItem>.Fail;
        }

        private async Task<Maybe<IWorkflowStepItem>> UpdateAndReturn<TEntity>(string id, UpdateDefinition<DbWorkflowStepItem> update)
        {
            var updatedProject = await Update<DbWorkflowStepItem>(id, update);
            return MaybeWorkflowStepItem(updatedProject);
        }

        private IMongoQueryable<DbWorkflowStepItem> Filter (RsMongoContext ctx, WorkflowStepItemFilter filter) 
        {
            var query = ctx.WorkflowStepsItems.AsQueryable();

            if (filter.Code.NotEmpty()) {
                query = query.Where(x => x.Code.CaseInsensitiveEquals(filter.Code));
            }

            if (filter.Name.NotEmpty()) {
                query = query.Where(x => x.Name.CaseInsensitiveEquals(filter.Name));
            }

            return query;
        }
    }
}