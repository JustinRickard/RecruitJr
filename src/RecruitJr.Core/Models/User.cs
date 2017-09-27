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
            string firstName,
            string lastName,
            string email,
            string username,
            DateTimeOffset dateCreated,
            DateTimeOffset lastModified,
            bool deleted
        ) : this(client, firstName, lastName, email, username)
        {
            Id = id;
            DateCreated = dateCreated;
            LastModified = lastModified;
            Deleted = deleted;
        }

        public User (
            string client, 
            string firstName,
            string lastName,
            string email,
            string username
        )
        {
            ClientId = client;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Username = username;
        }

        public string ClientId { get; set; }
        public Client Client { get; set; }
        public string Username  { get; set; }        
        public string PasswordHash { get; set; }
        public string Token { get; set; }
        public string FirstName { get; set; }
        public string LastName  { get; set; }
        public string Email     { get; set; }
        public bool EmailConfirmed { get; set; }

        public Dictionary<string, string> Settings { get; set; }
        public IEnumerable<string> Roles { get; set; }


        // Computed fields
        public string NormalizedUserName => Username.ToUpper();
        public bool IsValid =>
            FirstName.NotEmpty() &&
            LastName.NotEmpty() &&
            Email.NotEmpty() &&
            Username.NotEmpty();
    }
}