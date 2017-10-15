using System.Collections.Generic;

namespace RecruitJr.Core.Dto
{
    public class SeedClientAddDto
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string ParentCode { get; set; }
        public ClientSettings Settings { get; set; }
        public IEnumerable<string> Features { get; set; }
    }
}