using RecruitJr.Core.Dto;
using RecruitJr.Core.Models;

namespace RecruitJr.Core.ExtensionMethods
{
    public static class UserExtensions
    {
        public static User ToModel(this SeedUserAddDto dto, string clientId) {
            return new User {
                ClientId = clientId,
                Username = dto.Username,
                Email = dto.Email,
                Forename = dto.Forename,
                Surname = dto.Surname,
                Settings = dto.Settings,
                Roles = dto.Roles,
                EmailConfirmed = true,
                Token = null,                
                PasswordHash = string.Empty
            };
        }
    }
}