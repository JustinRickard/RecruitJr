using RecruitJr.Core.Classes;
using RecruitJr.Core.Interfaces.Common;

namespace RecruitJr.Core.Models.WorkflowStepItems
{
    public class WorkflowStepItemBase : DbRecordBase, ITranslatable, IHasCode
    {
        public string CultureCode { get; set; }
        public string Code { get; set; }
    }
}