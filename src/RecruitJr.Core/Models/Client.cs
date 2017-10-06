using System.Collections;
using System.Collections.Generic;
using RecruitJr.Core.ExtensionMethods;
using RecruitJr.Core.Dto;
using RecruitJr.Core.Classes;

namespace RecruitJr.Core.Models
{
    public class Client : DbRecordBase
    {
        public string ParentId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        // Settings are a dictionary to prevent model and database structure changing every time a new setting is added.
        public IDictionary<string, string> Settings { get; set; }

        public IEnumerable<string> Features { get; set; }

        // Computed fields
        public bool IsParent => ParentId.IsEmpty();        
        public bool IsChild => !IsParent;       

    }
}