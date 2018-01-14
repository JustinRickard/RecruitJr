using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecruitJr.DAL.Postgresql.Models
{
    public class DbUser : DbModelBase
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }

        [ForeignKey("ClientId")]
        public Guid ClientId { get; set; }
        public DbClient Client { get; set; }
    }
}