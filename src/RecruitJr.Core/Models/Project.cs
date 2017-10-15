using System;
using System.Collections.Generic;
using RecruitJr.Core.Classes;
using RecruitJr.Core.Dto;

namespace RecruitJr.Core.Models
{
    public class Project : DbRecordBase
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string WorkflowId { get; set; }
        public DateTimeOffset StartTime { get; set; }
        public DateTimeOffset EndTime { get; set; }
        public ProjectSettings Settings { get; set; }

        public Workflow Workflow { get; set; }

    }
}