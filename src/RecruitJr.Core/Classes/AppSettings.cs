using RecruitJr.Core.Interfaces;

namespace RecruitJr.Core.Classes
{
    public class AppSettings : IAppSettings
    {
        public string DatabaseName { get; set;}
        public string ConnectionString { get; set; }
    }
}