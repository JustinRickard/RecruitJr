using RecruitJr.Core.Enums;

namespace RecruitJr.Core.SearchFilters
{
    public class UserFilter
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender? Gender { get; set; }
        public string ClientId { get; set; }
    }
}