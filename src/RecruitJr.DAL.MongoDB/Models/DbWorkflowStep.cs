using System.Collections.Generic;
using MongoDB.Bson;
using RecruitJr.DAL.MongoDB.Interfaces;

namespace RecruitJr.DAL.MongoDB.Models
{
    public class DbWorkflowStep : DbRecordBaseWithCode, IDbRecordWithCode
    {
        public IEnumerable<ObjectId> ItemIds { get; set; }
    }
}