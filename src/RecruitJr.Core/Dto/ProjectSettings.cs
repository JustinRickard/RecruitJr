using RecruitJr.Core.Enums.Projects;

namespace RecruitJr.Core.Dto
{
    public class ProjectSettings
    {
        public LoginMethod LoginMethod { get; set; }
        public string Passcode { get; set; }
        public bool IsWebServiceIntegrated { get; set; }
    }
}