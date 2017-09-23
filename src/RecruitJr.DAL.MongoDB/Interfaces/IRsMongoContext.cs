using MongoDB.Driver;
using RecruitJr.DAL.MongoDB.Models;

namespace RecruitJr.DAL.MongoDB.Interfaces
{
    public interface IRsMongoContext
    {
        IMongoCollection<TEntity> GetCollection<TEntity>();
        IMongoCollection<DbAudit> AuditLogs { get; }
        IMongoCollection<DbRole> Roles { get; }
        IMongoCollection<DbUser> Users { get; }
    }
}