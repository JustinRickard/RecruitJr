using System;
using MongoDB.Bson;
using RecruitJr.DAL.MongoDB.Interfaces;
using MongoDB.Bson.Serialization.Attributes;

namespace RecruitJr.DAL.MongoDB.Models
{
    public abstract class DbRecordBase : IDbRecord
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public DateTimeOffset DateCreated { get; set; }

        public DateTimeOffset LastModified { get; set; }

        public bool Deleted { get; set; }
    }

    public abstract class DbRecordBaseWithCode : DbRecordBase, IDbRecordWithCode
    {
        public string Code { get; set; }
    }

    public abstract class  DbRecordBaseWithCodeAndCultureCode : DbRecordBaseWithCode
    {
        public string CultureCode { get; set; }
    }
}