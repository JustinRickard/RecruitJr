using System;
using MongoDB.Bson;
using RecruitJr.Core.Dto;
using RecruitJr.DAL.MongoDB.Interfaces;

namespace RecruitJr.DAL.MongoDB.Models
{
    public class DbProject : DbRecordBaseWithCode, IDbRecordWithCode
    {
        public string Name { get; set; }        
        public ObjectId WorkflowId { get; set; }
        public DateTimeOffset StartTime { get; set; }
        public DateTimeOffset EndTime { get; set; }
        public ProjectSettings Settings { get; set; }
    }
}