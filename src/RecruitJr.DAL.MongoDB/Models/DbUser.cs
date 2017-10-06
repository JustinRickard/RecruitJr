using System;
using RecruitJr.Core.Dto;
using RecruitJr.Core.Enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace RecruitJr.DAL.MongoDB.Models
{
    public class DbUser : DbRecordBase
    {
        public string ClientId { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string Token { get; set; }
        public IDictionary<string, string> Settings { get; set; }
        public IEnumerable<string> Roles { get; set; }
        /*
        [BsonRepresentation(BsonType.String)] 
        public Gender Gender { get; set; }
         */
    }
}