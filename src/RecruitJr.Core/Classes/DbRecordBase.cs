using System;

namespace RecruitJr.Core.Classes
{
    public class DbRecordBase
    {
        public string Id { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public DateTimeOffset LastModified { get; set; }
        public bool Deleted { get; set; }
    }
}