using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using RecruitJr.Core.Enums.WorkflowSteps;
using RecruitJr.Core.Interfaces.Common;
using RecruitJr.Core.Interfaces.Models;
using RecruitJr.DAL.MongoDB.Interfaces;

namespace RecruitJr.DAL.MongoDB.Models
{
    public class DbWorkflowStepItem : DbRecordBaseWithCode, IDbRecordWithCode, IHasName
    {        
        [BsonRepresentation(BsonType.String)] 
        public WorkflowStepItemType ItemType { get; set; }
        public string Name { get; set; }
        public string CultureCode { get; set; }
        public dynamic Content { get; set; }        
        
    }
}