using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using RecruitJr.Core.Classes;
using RecruitJr.Core.Dto;
using RecruitJr.Core.Models;

namespace RecruitJr.Core.Interfaces.Services
{
    public interface IUserService
    {
         Task<Result<User>> GetById(string id);

         Task<Result<User>> GetByUsername(string username);

         Task<Result<User>> GetByNormalizedUsername(string normalizedUsername);

         Task<Result<User>> GetByLoginCredentials(LoginCredentials credentials);

         Task<Result<string>> GetPasswordHash(string userId, CancellationToken cancellationToken);

         Task<IEnumerable<User>> GetAll();

         Task<Result<User>> Add(User user);

         Task<Result<User>> Update(User user);

         Task<Result> UpdatePassword(User user, string passwordHash, CancellationToken cancellationToken);

         Task<Result<User>> SetUsername(User user, string username, CancellationToken cancellationToken);

         Task<Result<User>> SetNormalizedUsername(User user, string normalizedUsername, CancellationToken cancellationToken);

         Task<Result> Delete(string id);

         Task<Result> Obliterate(string id);

    }
}