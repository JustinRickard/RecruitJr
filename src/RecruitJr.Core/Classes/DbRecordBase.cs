using System;
using RecruitJr.Core.Interfaces.Common;

namespace RecruitJr.Core.Classes
{
    public class DbRecordBase
    {
        public string Id { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public DateTimeOffset LastModified { get; set; }
        public bool Deleted { get; set; }
    }

    public class DbRecordBaseWithNameAndCode : DbRecordBase, IHasCode, IHasName
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}