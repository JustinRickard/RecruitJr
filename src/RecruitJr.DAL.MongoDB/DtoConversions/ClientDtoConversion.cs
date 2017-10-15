using System.Collections.Generic;
using System.Linq;
using RecruitJr.Core.Models;
using RecruitJr.DAL.MongoDB.Models;

namespace RecruitJr.DAL.MongoDB.DtoConversions
{
    public static class ClientDtoConversion
    {
        public static DbClient ToDb(this Client client) {
            return new DbClient {
                Id = client.Id,
                ParentId = client.ParentId,
                Name = client.Name,
                Code = client.Code,
                Settings = client.Settings,
                Features = client.Features
            };
        }

        public static Client ToModel(this DbClient client) {
            return new Client {
                Id = client.Id,
                ParentId = client.ParentId,
                Name = client.Name,
                Code = client.Code,
                Settings = client.Settings,
                Features = client.Features
            };
        }

        public static IEnumerable<Client> ToModel(this IEnumerable<DbClient> clients) {
            return clients != null 
                ? clients.Select(client => client.ToModel())
                : new List<Client>();
        }

        public static IEnumerable<DbClient> ToModel(this IEnumerable<Client> clients) {
            return clients != null
                ? clients.Select(client => client.ToDb())
                : new List<DbClient>();
        }
    }
}