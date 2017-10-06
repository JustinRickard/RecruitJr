using RecruitJr.Core.Dto;
using RecruitJr.Core.Models;

namespace RecruitJr.Core.ExtensionMethods
{
    public static class ClientExtensions
    {
        public static Client ToModel(this SeedClientAddDto dto, string parentId) {
            return new Client {
                Code = dto.Code,
                Name = dto.Name,
                Features = dto.Features,
                Settings = dto.Settings,
                ParentId = parentId
            };
        }
    }
}