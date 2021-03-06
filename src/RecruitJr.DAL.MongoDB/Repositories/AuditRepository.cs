using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecruitJr.Core.Classes;
using RecruitJr.Core.Dto;
using RecruitJr.Core.Enums;
using RecruitJr.Core.Interfaces.Repositories;
using RecruitJr.Core.SearchFilters;
using RecruitJr.DAL.MongoDB.DtoConversions;
using RecruitJr.DAL.MongoDB.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace RecruitJr.DAL.MongoDB.Repositories
{
    public class AuditRepository : RepositoryBase, IAuditRepository
    {
        public AuditRepository(
            IOptions<AppSettings> appSettings
            ) : base(appSettings) {
        }
        public async Task Add(AuditType type, string message) {
            var dbAudit = new DbAudit (type, message);
            SetInitialRecordValues(dbAudit);

            using (var ctx = GetContext()) {
                await ctx.AuditLogs.InsertOneAsync(dbAudit);
            }
        }

        public async Task<IEnumerable<Audit>> Get(AuditFilter filter) {
            using (var ctx = GetContext()) {

                var auditLogs = await Filter(ctx, filter)
                    .ToListAsync();

                return auditLogs.ToDto();
            }
        }

        private IMongoQueryable<DbAudit> Filter (RsMongoContext ctx, AuditFilter filter) {
            var query = ctx.AuditLogs.AsQueryable();

            if (filter.From.HasValue) {
                query = query.Where(x => x.DateCreated >= filter.From);
            }

            if (filter.To.HasValue) {
                query = query.Where(x => x.DateCreated <= filter.To);
            }

            if (filter.Type.HasValue) {
                query = query.Where(x => x.Type == filter.Type);
            }

            return query;
        }
    }
}