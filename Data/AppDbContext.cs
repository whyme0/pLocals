using Microsoft.EntityFrameworkCore;
using pLocals.Models;
using System.Reflection.Metadata;

namespace pLocals.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
            Database.EnsureCreated();
        }

        public DbSet<Account> Accounts { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .HasIndex(a => a.Title)
                .IsUnique();
        }
    }
}
