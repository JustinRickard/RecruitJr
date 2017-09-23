using RecruitJr.Core.Interfaces.Helpers;

namespace RecruitJr.Core.Helpers
{
    public class PasswordHelper : IPasswordHelper
    {
        int workFactor = 10;

        public string Encrypt(string password)
        {
            var salt = BCrypt.Net.BCrypt.GenerateSalt(workFactor);
            return BCrypt.Net.BCrypt.HashPassword(password, salt);
        }

        public bool IsValid(string rawPassword, string hashedPassword) {
            return BCrypt.Net.BCrypt.Verify(rawPassword, hashedPassword);
        }
    }
}