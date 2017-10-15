using RecruitJr.Core.Dto;
using System.Collections.Generic;
using RecruitJr.DAL.MongoDB.Interfaces;

namespace RecruitJr.DAL.MongoDB.Models
{
    public class DbClient : DbRecordBaseWithCode, IDbRecordWithCode
    {
        public string ParentId { get; set; }
        public string Name { get; set; }
        public ClientSettings Settings { get; set; }
        public IEnumerable<string> Features { get; set; }

    }
}