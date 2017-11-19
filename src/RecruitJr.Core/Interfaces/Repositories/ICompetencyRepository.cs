using RecruitJr.Core.Models;
using RecruitJr.Core.SearchFilters;

namespace RecruitJr.Core.Interfaces.Repositories
{
    public interface ICompetencyRepository : IRepository<Competency, CompetencyFilter>, IRepositoryHasCode<Competency>
    {         
    }
}