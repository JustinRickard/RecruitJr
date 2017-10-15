using System.Collections.Generic;
using MongoDB.Bson;
using RecruitJr.DAL.MongoDB.Interfaces;

namespace RecruitJr.DAL.MongoDB.Models
{
    public class DbWorkflow : DbRecordBaseWithCode, IDbRecordWithCode
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IEnumerable<ObjectId> WorkflowStepIds { get; set; }
    }
}