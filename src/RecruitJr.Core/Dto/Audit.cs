using RecruitJr.Core.Classes;
using RecruitJr.Core.Enums;

namespace RecruitJr.Core.Dto
{
    public class Audit : DbRecordBase
    {
        public AuditType Type { get; set; }
        public string Message { get; set; }
    }
}