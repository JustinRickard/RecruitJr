using System.Collections.Generic;
using System.Linq;
using RecruitJr.DAL.MongoDB.Models;
using RecruitJr.Core.Models;
using MongoDB.Bson;

namespace RecruitJr.DAL.MongoDB.DtoConversions
{
    public static class UserDtoConversion
    {
        public static User ToDto(this DbUser dbUser) 
        {
            return new User {
                Id = dbUser.Id,
                Username = dbUser.Username,
                Email = dbUser.Email,
                Forename = dbUser.Forename,
                Surname = dbUser.Surname,
                PasswordHash = dbUser.PasswordHash,
                DateCreated = dbUser.DateCreated,
                LastModified = dbUser.LastModified,
                Deleted = dbUser.Deleted,
                EmailConfirmed = dbUser.EmailConfirmed,
                Token = dbUser.Token
            };
        }

        public static DbUser ToDb(this User user) 
        {
            return new DbUser {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                Forename = user.Forename,
                Surname = user.Surname,
                PasswordHash = user.PasswordHash,
                Deleted = user.Deleted,
                EmailConfirmed = user.EmailConfirmed,
                Token = user.Token,
            };
        }

        public static IEnumerable<User> ToDto(this IEnumerable<DbUser> users) {
            return users != null 
                ? users.Select(user => user.ToDto())
                : new List<User>();
        }

        public static IEnumerable<DbUser> ToDto(this IEnumerable<User> users) {
            return users != null
                ? users.Select(user => user.ToDb())
                : new List<DbUser>();
        }
    }
}