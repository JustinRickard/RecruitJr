using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using RecruitJr.Core.Classes;
using RecruitJr.Core.ExtensionMethods;
using RecruitJr.Core.Interfaces.Helpers;
using RecruitJr.Core.Interfaces.Repositories;
using RecruitJr.Core.Models;
using RecruitJr.Core.SearchFilters;
using RecruitJr.DAL.MongoDB.DtoConversions;
using RecruitJr.DAL.MongoDB.Models;

namespace RecruitJr.DAL.MongoDB.Repositories
{
    public class ClientRepository : RepositoryBase, IClientRepository
    {
        public ClientRepository(
            IOptions<AppSettings> appSettings,
            IPasswordHelper passwordHelper
        ) : base(appSettings) 
        {
        }        
        public async Task<Maybe<Client>> Add(Client client)
        {
            var addedClient = await Add<DbClient>(client.ToDb());
            return MaybeClient(addedClient);
        }

        public async Task Delete(string id)
        {
            await Delete<DbClient>(id);
        }

        public async Task<IEnumerable<Client>> Get(ClientFilter filter)
        {
            using (var ctx = GetContext()) {
                var clients = await Filter(ctx, filter).ToListAsync();
                return clients.ToModel();
            }
        }

        public async Task<IEnumerable<Client>> GetAll()
        {
            var dbClients = await GetAllNotDeleted<DbClient>();
            return dbClients.ToModel();
        }

        public async Task<Maybe<Client>> GetByCode(string code)
        {
            var client = await GetOneByCode<DbClient>(code);
            return MaybeClient(client);
        }

        public async Task<Maybe<Client>> GetById(string id)
        {
            var dbUser = await GetOne<DbClient>(id);
                return MaybeClient(dbUser);
        }

        public async Task Obliterate(string id)
        {
            await Obliterate<DbClient>(id);
        }

        public async Task<Maybe<Client>> Update(Client client)
        {
            var update = Builders<DbClient>.Update
                .Set(x => x.ParentId, client.ParentId)
                .Set(x => x.Code, client.Code)
                .Set(x => x.Features, client.Features)
                .Set(x => x.Settings, client.Settings)
                .Set(x => x.Name, client.Name);

            return await UpdateAndReturn<DbClient>(client.Id, update);           
        }
        // HELPER METHODS

        private Maybe<Client> MaybeClient(Maybe<DbClient> Client) 
        {
            return Client.HasValue
                    ? MaybeClient(Client.Value)
                    : Maybe<Client>.Fail;
        }

        private Maybe<Client> MaybeClient(DbClient client) 
        {
            return client != null 
                    ? new Maybe<Client>(client.ToModel())
                    : Maybe<Client>.Fail;
        }

        private async Task<Maybe<Client>> UpdateAndReturn<TEntity>(string id, UpdateDefinition<DbClient> update)
        {
            var updatedClient = await Update<DbClient>(id, update);
            return MaybeClient(updatedClient);
        }

        private IMongoQueryable<DbClient> Filter (RsMongoContext ctx, ClientFilter filter) 
        {
            var query = ctx.Clients.AsQueryable();

            if (filter.Code.NotEmpty()) {
                query = query.Where(x => x.Code.CaseInsensitiveEquals(filter.Code));
            }

            if (filter.Name.NotEmpty()) {
                query = query.Where(x => x.Name.CaseInsensitiveEquals(filter.Name));
            }

            if (filter.IsParent.HasValue) {
                query = query.Where(x => x.ParentId.NotEmpty());
            }

            return query;
        }
    }
}