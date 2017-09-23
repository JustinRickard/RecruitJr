using System.Collections.Generic;
using System.Threading.Tasks;
using RecruitJr.Core.Dto;
using RecruitJr.Core.Enums;
using RecruitJr.Core.SearchFilters;

namespace RecruitJr.Core.Interfaces.Repositories
{
    public interface IAuditRepository
    {
        Task Add(AuditType type, string message);

        Task<IEnumerable<Audit>> Get(AuditFilter filter);
    }
}