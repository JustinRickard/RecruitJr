using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using RecruitJr.Core.Classes;
using RecruitJr.Core.Dto;
using RecruitJr.Core.Models;
using RecruitJr.Core.SearchFilters;

namespace RecruitJr.Core.Interfaces.Repositories
{
    public interface IUserRepository : IRepository<User, UserFilter>
    {
         Task<Maybe<User>> GetByUsername(string username);

         Task<Maybe<User>> GetByNormalizedUsername(string username);

         Task<Maybe<User>> GetByLoginCredentials (LoginCredentials credentials);

         Task<Maybe<string>> GetPasswordHash (string userId);

         Task<Maybe<User>> UpdateUsername (User user, string username, CancellationToken cancellationToken);

         Task<Maybe<User>> UpdatePassword(User user, string passwordHash, CancellationToken cancellationToken);
    }
}