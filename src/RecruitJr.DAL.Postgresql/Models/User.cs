using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecruitJr.DAL.Postgresql.Models
{
    public class User : DbModelBase
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }

        [ForeignKey("ClientId")]
        public Guid ClientId { get; set; }
        public Client Client { get; set; }
    }
}