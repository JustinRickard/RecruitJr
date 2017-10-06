using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core;
using MongoDB.Driver.Linq;
using RecruitJr.Core.Dto;
using RecruitJr.Core.Interfaces;
using RecruitJr.Core.Classes;
using RecruitJr.DAL.MongoDB.Interfaces;
using RecruitJr.DAL.MongoDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RecruitJr.DAL.MongoDB
{
    public class RsMongoContext : IDisposable, IRsMongoContext
    {
        public IMongoDatabase Database;

        public RsMongoContext(IAppSettings appSettings) 
        {
            var client = new MongoClient(appSettings.ConnectionString);
            this.Database = client.GetDatabase(appSettings.DatabaseName);
        }

        public IMongoCollection<TEntity> GetCollection<TEntity>()
        {
            var collectionName = GetCollectionName<TEntity>();
            return Database.GetCollection<TEntity>(collectionName);
        }        

        public IMongoCollection<DbAudit> AuditLogs => GetCollection<DbAudit>();
        public IMongoCollection<DbRole> Roles => GetCollection<DbRole>();
        public IMongoCollection<DbUser> Users => GetCollection<DbUser>();
        public IMongoCollection<DbClient> Clients => GetCollection<DbClient>();

        public void Dispose() {
            this.Database = null;
        }

        private Dictionary<Type, string> dbEntityToCollectionNameMappings = new Dictionary<Type, string>() {
            { typeof(DbAudit), Constants.Collections.AuditLogs },
            { typeof(DbRole), Constants.Collections.Roles },
            { typeof(DbUser), Constants.Collections.Users },
            { typeof(DbClient), Constants.Collections.Clients }
        };

        private string GetCollectionName<TEntity>()
        {
            var type = typeof(TEntity);
            return dbEntityToCollectionNameMappings.First(x => x.Key == type).Value;            
        }
    }
}