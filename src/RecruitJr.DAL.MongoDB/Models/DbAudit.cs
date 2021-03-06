using System;
using RecruitJr.Core.Enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RecruitJr.DAL.MongoDB.Models
{
    public class DbAudit : DbRecordBase
    {
        public DbAudit() {}
        
        public DbAudit(AuditType type, string message) {
            Type = type;
            Message = message;
        }

        [BsonRepresentation(BsonType.String)] 
        public AuditType Type { get; set; } 

        public string Message { get; set; }
    }
}