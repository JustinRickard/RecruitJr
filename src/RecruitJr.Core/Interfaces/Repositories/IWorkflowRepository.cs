using RecruitJr.Core.Models;
using RecruitJr.Core.SearchFilters;

namespace RecruitJr.Core.Interfaces.Repositories
{
    public interface IWorkflowRepository : IRepository<Workflow, WorkflowFilter>, IRepositoryHasCode<Workflow>
    {
         
    }
}