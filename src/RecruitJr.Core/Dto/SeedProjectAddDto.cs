using System;
using RecruitJr.Core.Enums.Projects;

namespace RecruitJr.Core.Dto
{
    public class SeedProjectAddDto
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string WorkflowCode { get; set; }
        public LoginMethod LoginMethod { get; set; }        
        public DateTimeOffset StartTime { get; set; }
        public DateTimeOffset EndTime { get; set; }
        public ProjectSettings Settings { get; set; }
    }
}