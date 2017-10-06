using RecruitJr.Core.Dto;
using System.Collections.Generic;
using RecruitJr.DAL.MongoDB.Interfaces;

namespace RecruitJr.DAL.MongoDB.Models
{
    public class DbClient : DbRecordBase, IDbRecordWithCode
    {
        public string ParentId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public IDictionary<string, string> Settings { get; set; }
        public IEnumerable<string> Features { get; set; }

    }
}