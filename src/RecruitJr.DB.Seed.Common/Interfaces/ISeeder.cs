using System.Threading.Tasks;
using RecruitJr.Core.Classes;

namespace RecruitJr.DB.Seed.Common.Interfaces
{
    public interface ISeeder
    {
        Task<Result> Seed();
    }
}