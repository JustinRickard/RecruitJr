using System;
using System.Collections.Generic;
using RecruitJr.Core.Classes;
using RecruitJr.Core.Enums;
using RecruitJr.Core.ExtensionMethods;

namespace RecruitJr.Core.Models
{
    public class User : DbRecordBase
    {
        public User() {}

        public User(
            string id,
            string client, 
            string forename,
            string surname,
            string email,
            string username,
            DateTimeOffset dateCreated,
            DateTimeOffset lastModified,
            bool deleted
        ) : this(client, forename, surname, email, username)
        {
            Id = id;
            DateCreated = dateCreated;
            LastModified = lastModified;
            Deleted = deleted;
        }

        public User (
            string client, 
            string forename,
            string surname,
            string email,
            string username
        )
        {
            ClientId = client;
            Forename = forename;
            Surname = surname;
            Email = email;
            Username = username;
        }

        public string ClientId { get; set; }
        public Client Client { get; set; }
        public string Username  { get; set; }        
        public string PasswordHash { get; set; }
        public string Token { get; set; }
        public string Forename { get; set; }
        public string Surname  { get; set; }
        public string Email     { get; set; }
        public bool EmailConfirmed { get; set; }

        public Dictionary<string, string> Settings { get; set; }
        public IEnumerable<string> Roles { get; set; }


        // Computed fields
        public string NormalizedUserName => Username.ToUpper();
        public bool IsValid =>
            Forename.NotEmpty() &&
            Surname.NotEmpty() &&
            Email.NotEmpty() &&
            Username.NotEmpty();
    }
}