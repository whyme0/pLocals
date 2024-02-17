using Microsoft.EntityFrameworkCore;
using pLocals.Models;

namespace pLocals.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
            Database.EnsureCreated();
        }

        public DbSet<Account> Accounts { get; set; } = null!;
        public DbSet<Note> Notes { get; set; } = null!;
    }
}
