using System;
using RecruitJr.Core.Enums;

namespace RecruitJr.Core.SearchFilters
{
    public class AuditFilter
    {
        public AuditType? Type { get; set; }

        public string Message { get; set; }

        public DateTimeOffset? From { get; set; }

        public DateTimeOffset? To { get; set; }
    }
}