using RecruitJr.Core.Models;
using RecruitJr.Core.SearchFilters;

namespace RecruitJr.Core.Interfaces.Repositories
{
    public interface IProjectRepository : IRepository<Project, ProjectFilter>, IRepositoryHasCode<Project>
    {         
    }
}