using RecruitJr.Core.Models;
using RecruitJr.Core.SearchFilters;

namespace RecruitJr.Core.Interfaces.Repositories
{
    public interface IWorkflowStepRepository : IRepository<WorkflowStep, WorkflowStepFilter>, IRepositoryHasCode<WorkflowStep>
    {
         
    }
}