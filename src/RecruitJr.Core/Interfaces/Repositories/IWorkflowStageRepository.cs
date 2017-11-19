using RecruitJr.Core.Models;
using RecruitJr.Core.SearchFilters;

namespace RecruitJr.Core.Interfaces.Repositories
{
    public interface IWorkflowStageRepository : IRepository<WorkflowStage, WorkflowStageFilter>, IRepositoryHasCode<WorkflowStage>
    {         
    }
}