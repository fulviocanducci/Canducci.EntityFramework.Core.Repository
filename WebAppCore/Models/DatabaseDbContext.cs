using Microsoft.EntityFrameworkCore;
using System;
namespace WebAppCore.Models
{
    public class DatabaseDbContext: DbContext
    {
        public DbSet<People> People { get; set; }

        public DatabaseDbContext(DbContextOptions options) 
            : base(options)
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }            
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
