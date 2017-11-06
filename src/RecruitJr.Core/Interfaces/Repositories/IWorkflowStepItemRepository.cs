using System.Collections.Generic;
using System.Threading.Tasks;
using RecruitJr.Core.Classes;
using RecruitJr.Core.Interfaces.Models;
using RecruitJr.Core.SearchFilters;

namespace RecruitJr.Core.Interfaces.Repositories
{
    public interface IWorkflowStepItemRepository : IRepository<IWorkflowStepItem, WorkflowStepItemFilter>, IRepositoryHasCode<IWorkflowStepItem>
    {
    }
}