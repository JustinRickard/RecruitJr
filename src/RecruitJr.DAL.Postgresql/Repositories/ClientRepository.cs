using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using RecruitJr.Core.Classes;
using RecruitJr.Core.Models;
using RecruitJr.Core.Interfaces.Repositories;
using RecruitJr.DAL.Postgresql.Conversions;
using RecruitJr.DAL.Postgresql.Models;
using RecruitJr.Core.SearchFilters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RecruitJr.DAL.Postgresql.Repositories
{    
    public class ClientRepository : IClientRepository
    {
        RsPostgresContext ctx;

        public ClientRepository(RsPostgresContext context) {
            this.ctx = context;
        }

        public async Task<Maybe<Client>> Add(Client client)
        {
            var dbClient = client.ToDb();
            await ctx.Clients.AddAsync(dbClient);
            ctx.SaveChanges();
            return MaybeClient(dbClient);
        }

        public async Task Delete(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Client>> Get(ClientFilter filter)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Client>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<Maybe<Client>> GetByCode(string code)
        {
            throw new NotImplementedException();
        }

        public async Task<Maybe<Client>> GetById(string id)
        { 
            var client = await ctx.Clients.FirstOrDefaultAsync(x => x.Id == Guid.Parse(id));
            return MaybeClient(client);
        }

        public async Task Obliterate(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<Maybe<Client>> Update(Client user)
        {
            throw new NotImplementedException();
        }

        /*
        RsPostgresContext ctx;
        public ClientRepository(RsPostgresContext context) {
            ctx = context;
        }        

        public Maybe<Client> GetById(string idString) {
            Guid id = Guid.Parse(idString);
            
            var client = ctx.Clients
            .FirstOrDefault(x => x.Id == id);

            return MaybeClient(client);               
        }

         */

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
    }
}