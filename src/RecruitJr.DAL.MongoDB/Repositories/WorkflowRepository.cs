using System.Collections.Generic;
using System.Threading.Tasks;
using RecruitJr.Core.Classes;
using RecruitJr.Core.Interfaces.Repositories;
using RecruitJr.Core.Models;
using RecruitJr.Core.SearchFilters;

namespace RecruitJr.DAL.MongoDB.Repositories
{
    public class WorkflowRepository : IWorkflowRepository
    {
        public Task<Maybe<Workflow>> Add(Workflow user)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Workflow>> Get(WorkflowFilter filter)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Workflow>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<Maybe<Workflow>> GetByCode(string code)
        {
            throw new System.NotImplementedException();
        }

        public Task<Maybe<Workflow>> GetById(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task Obliterate(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Maybe<Workflow>> Update(Workflow user)
        {
            throw new System.NotImplementedException();
        }
    }
}