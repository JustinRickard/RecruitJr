using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace RecruitJr.DAL.Postgresql.Models
{
    public abstract class DbModelBase
    {
        [Key]
        public Guid Id { get; set; }

        public bool IsDeleted { get; set; }

        public DateTimeOffset DateAdded { get; set; }

        public DateTimeOffset LastModified { get; set; }        
    }
}