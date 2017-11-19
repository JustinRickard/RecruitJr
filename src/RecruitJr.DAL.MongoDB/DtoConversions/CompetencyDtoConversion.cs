using RecruitJr.Core.Models;
using RecruitJr.DAL.MongoDB.Models;

namespace RecruitJr.DAL.MongoDB.DtoConversions
{
    public static class CompetencyDtoConversion
    {
        public static Competency ToModel(this DbCompetency competency) {
            return new Competency {
                Id = competency.Id,
                Code = competency.Code,
                Name = competency.Name,
                DateCreated = competency.DateCreated,
                Deleted = competency.Deleted,
                LastModified = competency.LastModified                
            };
        }

        public static DbCompetency ToDb(this Competency competency) {
            return new DbCompetency {
                Id = competency.Id,
                Code = competency.Code,
                Name = competency.Name,
                DateCreated = competency.DateCreated,
                Deleted = competency.Deleted,
                LastModified = competency.LastModified  
            };
        }
    }
}