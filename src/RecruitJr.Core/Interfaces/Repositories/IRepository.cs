using System.Collections.Generic;
using System.Threading.Tasks;
using RecruitJr.Core.Classes;

namespace RecruitJr.Core.Interfaces.Repositories
{
    public interface IRepository<T, TFilter>
    {
        Task<Maybe<T>> GetById (string id);
         Task<IEnumerable<T>> GetAll();
         Task<IEnumerable<T>> Get(TFilter filter);
         Task<Maybe<T>> Add (T user);
         Task<Maybe<T>> Update (T user);
         Task Delete(string id);
         Task Obliterate(string id);
    }
}