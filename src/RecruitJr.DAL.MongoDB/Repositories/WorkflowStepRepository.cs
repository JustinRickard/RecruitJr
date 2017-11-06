using System.Collections.Generic;
using System.Threading.Tasks;
using RecruitJr.Core.Classes;
using RecruitJr.Core.Interfaces.Repositories;
using RecruitJr.Core.Models;
using RecruitJr.Core.SearchFilters;

namespace RecruitJr.DAL.MongoDB.Repositories
{
    public class WorkflowStepRepository : IWorkflowStepRepository
    {
        public Task<Maybe<WorkflowStep>> Add(WorkflowStep user)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<WorkflowStep>> Get(WorkflowStepFilter filter)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<WorkflowStep>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<Maybe<WorkflowStep>> GetByCode(string code)
        {
            throw new System.NotImplementedException();
        }

        public Task<Maybe<WorkflowStep>> GetById(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task Obliterate(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Maybe<WorkflowStep>> Update(WorkflowStep user)
        {
            throw new System.NotImplementedException();
        }
    }
}