using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using RecruitJr.Core.Enums.WorkflowSteps;
using RecruitJr.Core.Interfaces.Models;
using RecruitJr.DAL.MongoDB.Interfaces;

namespace RecruitJr.DAL.MongoDB.Models
{
    public class DbWorkflowStepItem : DbRecordBaseWithCode, IDbRecordWithCode
    {        
        [BsonRepresentation(BsonType.String)] 
        public WorkflowStepItemType ItemType { get; set; }
        public IDbWorkflowStepItem Content { get; set; }
    }
}