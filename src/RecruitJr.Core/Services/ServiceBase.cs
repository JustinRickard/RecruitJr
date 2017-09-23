using System;
using System.Threading.Tasks;
using RecruitJr.Core.Enums;
using RecruitJr.Core.Interfaces.Helpers;
using RecruitJr.Core.Interfaces.Repositories;

namespace RecruitJr.Core.Services
{
    public class ServiceBase
    {
        IAuditHelper auditHelper;

        public ServiceBase (
            IAuditHelper auditHelper
        ) {
            this.auditHelper = auditHelper;
        }

        public async Task Audit(AuditType type, string message)
        {
            await auditHelper.Audit(type, message);
        }

        public async Task Audit<T>(AuditType type, string prefix, T objectToSerialize)
        {
            await auditHelper.Audit<T>(type, prefix, objectToSerialize);
        }

        public async Task Audit<T1,T2>(AuditType type, string prefix, T1 objectToSerialize, T2 parameters)
        {
            await auditHelper.Audit<T1,T2>(type, prefix, objectToSerialize, parameters);
        }
    }
}