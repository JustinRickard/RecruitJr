using System.Threading.Tasks;
using RecruitJr.Core.Classes;

namespace RecruitJr.Core.Interfaces.Repositories
{
    public interface IRepositoryHasCode<T>
    {
         Task<Maybe<T>> GetByCode(string code);
    }
}