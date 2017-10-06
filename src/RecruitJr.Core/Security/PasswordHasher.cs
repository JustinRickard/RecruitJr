using Microsoft.AspNetCore.Identity;
using RecruitJr.Core.Interfaces.Helpers;
using RecruitJr.Core.Models;

namespace RecruitJr.Core.Security
{
    public class PasswordHasher : IPasswordHasher<User>
    {
        IPasswordHelper passwordHelper;

        public PasswordHasher(IPasswordHelper passwordHelper) {
            this.passwordHelper = passwordHelper;
        }

        public string HashPassword(User user, string password)
        {
            string hash = passwordHelper.Encrypt(password);
            user.PasswordHash = hash;

            return hash;
        }

        public PasswordVerificationResult VerifyHashedPassword(User user, string hashedPassword, string providedPassword)
        {
            bool isValid = passwordHelper.IsValid(providedPassword, hashedPassword);
            return isValid 
                ? PasswordVerificationResult.Success
                : PasswordVerificationResult.Failed;
        }
    }
}