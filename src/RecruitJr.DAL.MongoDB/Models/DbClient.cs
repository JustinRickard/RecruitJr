using RecruitJr.Core.Dto;
using System.Collections.Generic;

namespace RecruitJr.DAL.MongoDB.Models
{
    public class DbClient : DbRecordBase
    {
        public string ParentId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public Dictionary<string, string> Settings { get; set; }

    }
}