using Microsoft.EntityFrameworkCore;
using RecruitJr.Core.Interfaces;
using RecruitJr.DAL.Postgresql.Models;

namespace RecruitJr.DAL.Postgresql
{
    public class RsPostgresContext : DbContext
    {
        public RsPostgresContext(DbContextOptions options) : base(options) { 
            // Tracking is not required for disconnected web apps.
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        }

        public DbSet<DbUser> Users { get; set; }  
        public DbSet<DbClient> Clients { get; set; }  
    }
}