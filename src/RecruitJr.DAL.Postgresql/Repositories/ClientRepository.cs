using System;
using System.Linq;
using RecruitJr.Core.Classes;
using RecruitJr.Core.Models;
using RecruitJr.DAL.Postgresql.Conversions;
using RecruitJr.DAL.Postgresql.Models;

namespace RecruitJr.DAL.Postgresql.Repositories
{    
    public class ClientRepository
    {
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