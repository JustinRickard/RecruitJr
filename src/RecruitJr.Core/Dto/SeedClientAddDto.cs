using System.Collections.Generic;

namespace RecruitJr.Core.Dto
{
    public class SeedClientAddDto
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string ParentCode { get; set; }
        public IDictionary<string,string> Settings { get; set; }
        public IEnumerable<string> Features { get; set; }
    }
}