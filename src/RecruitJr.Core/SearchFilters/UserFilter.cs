using RecruitJr.Core.Enums;

namespace RecruitJr.Core.SearchFilters
{
    public class UserFilter
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }
        public string ClientId { get; set; }
    }
}