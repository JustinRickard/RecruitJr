using Microsoft.EntityFrameworkCore;
using RecruitJr.Core.Interfaces;
using RecruitJr.DAL.Postgresql.Models;

namespace RecruitJr.DAL.Postgresql
{
    public class RsPostgresContext : DbContext
    {
        public RsPostgresContext(DbContextOptions<RsPostgresContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }  
        public DbSet<Client> Clients { get; set; }  
    }
}