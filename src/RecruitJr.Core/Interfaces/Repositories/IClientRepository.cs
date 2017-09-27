using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using RecruitJr.Core.Classes;
using RecruitJr.Core.Dto;
using RecruitJr.Core.Models;
using RecruitJr.Core.SearchFilters;

namespace RecruitJr.Core.Interfaces.Repositories
{
    public interface IClientRepository
    {
         Task<Maybe<Client>> GetById (string id);
    }
}