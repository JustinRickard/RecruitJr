using System.Collections.Generic;
using System.Threading.Tasks;
using RecruitJr.Core.Classes;
using RecruitJr.Core.Dto;

namespace RecruitJr.Core.Interfaces.Repositories
{
    public interface IRoleRepository
    {
        Task<Maybe<Role>> GetById (string id);

        Task<Maybe<Role>> GetByName (string name);

        Task<IEnumerable<Role>> GetAll();

        Task<Maybe<Role>> Add (Role role);

        Task<Maybe<Role>> Update (Role user);

        Task Delete (string id);

        Task Obliterate(string id);
    }
}