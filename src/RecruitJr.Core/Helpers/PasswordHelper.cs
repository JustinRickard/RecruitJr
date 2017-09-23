using RecruitJr.Core.Interfaces.Helpers;

namespace RecruitJr.Core.Helpers
{
    public class PasswordHelper : IPasswordHelper
    {
        public string Encrypt(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool IsValid(string rawPassword, string hashedPassword) {
            return BCrypt.Net.BCrypt.Verify(rawPassword, hashedPassword);
        }
    }
}