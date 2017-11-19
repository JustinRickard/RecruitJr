using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using RecruitJr.Core.Classes;
using RecruitJr.Core.ExtensionMethods;
using RecruitJr.Core.Interfaces.Repositories;
using RecruitJr.Core.Models;
using RecruitJr.Core.SearchFilters;
using RecruitJr.DAL.MongoDB.Models;
using RecruitJr.DAL.MongoDB.DtoConversions;
using DbRecordBaseWithCode = RecruitJr.DAL.MongoDB.Models.DbRecordBaseWithCode;

namespace RecruitJr.DAL.MongoDB.Repositories
{
    public class CompetencyRepository : RepositoryBase, ICompetencyRepository
    {
        public CompetencyRepository(
            IOptions<AppSettings> appSettings
        ) : base(appSettings) 
        {
        } 

        public Task<Maybe<Competency>> Add(Competency user)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Competency>> Get(CompetencyFilter filter)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Competency>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<Maybe<Competency>> GetByCode(string code)
        {
            throw new System.NotImplementedException();
        }

        public Task<Maybe<Competency>> GetById(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task Obliterate(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Maybe<Competency>> Update(Competency user)
        {
            throw new System.NotImplementedException();
        }

        // HELPER METHODS

        private Maybe<Competency> MaybeCompetency(Maybe<DbCompetency> competency) 
        {
            return competency.HasValue
                    ? MaybeCompetency(competency.Value)
                    : Maybe<Competency>.Fail;
        }

        private Maybe<Competency> MaybeCompetency(DbCompetency competency) 
        {
            return competency != null 
                    ? new Maybe<Competency>(competency.ToModel())
                    : Maybe<Competency>.Fail;
        }

        private async Task<Maybe<Competency>> UpdateAndReturn<TEntity>(string id, UpdateDefinition<DbCompetency> update)
        {
            var updatedClient = await Update<DbCompetency>(id, update);
            return MaybeCompetency(updatedClient);
        }

        private IMongoQueryable<DbCompetency> Filter (RsMongoContext ctx, CompetencyFilter filter) 
        {
            var query = ctx.Competencies.AsQueryable();

            if (filter.Code.NotEmpty()) {
                query = query.Where(x => x.Code.CaseInsensitiveEquals(filter.Code));
            }

            if (filter.Name.NotEmpty()) {
                query = query.Where(x => x.Name.CaseInsensitiveEquals(filter.Name));
            }

            if (filter.CultureCode.NotEmpty()) {
                query = query.Where(x => x.CultureCode.CaseInsensitiveEquals(filter.CultureCode));
            }            

            return query;
        }
    }
}