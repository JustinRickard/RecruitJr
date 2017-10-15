using System.Collections.Generic;

namespace RecruitJr.Core.Dto
{
    public class SeedUserAddDto
    {
        public string ClientCode { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string EmailConfirmed { get; set; }
        public string Forename { get; set;}
        public string Surname { get; set; }
        
        public UserSettings Settings { get; set; }
        public IEnumerable<string> Roles { get; set; }
    }
}