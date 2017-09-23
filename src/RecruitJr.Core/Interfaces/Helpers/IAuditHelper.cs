using System.Threading.Tasks;
using RecruitJr.Core.Enums;

namespace RecruitJr.Core.Interfaces.Helpers
{
    public interface IAuditHelper
    {
        Task Audit(AuditType type, string message);
        Task Audit<T>(AuditType type, string prefix, T objectToSerialize);
        Task Audit<T1,T2>(AuditType type, string prefix, T1 objectToSerialize, T2 parameters);
        
    }
}