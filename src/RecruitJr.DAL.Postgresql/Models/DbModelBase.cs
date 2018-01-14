using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace RecruitJr.DAL.Postgresql.Models
{
    public abstract class DbModelBase
    {
        [Key]
        public Guid Id { get; set; }

        public bool Deleted { get; set; }

        public DateTimeOffset DateCreated { get; set; }

        public DateTimeOffset LastModified { get; set; }        
    }
}