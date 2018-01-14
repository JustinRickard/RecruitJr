using RecruitJr.Core.Models;
using RecruitJr.DAL.Postgresql.Models;

namespace RecruitJr.DAL.Postgresql.Conversions
{
    public static class ClientConversions
    {
        public static Client ToModel(this DbClient dbClient) {

            if (dbClient == null) return null;

            return new Client {
                Id = dbClient.Id.ToString(),
                Name = dbClient.Name,
                LastModified = dbClient.LastModified,
                DateCreated = dbClient.DateCreated,
                Deleted = dbClient.Deleted,
            };
        }
        
    }
}