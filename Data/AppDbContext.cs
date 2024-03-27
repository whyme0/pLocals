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
            modelBuilder.Entity<Account>()
                .Property(a => a.Title)
                .IsRequired();
            modelBuilder.Entity<Account>()
                .Property(a => a.Login)
                .IsRequired();
            modelBuilder.Entity<Account>()
                .Property(a => a.Password)
                .IsRequired();

            modelBuilder.Entity<Account>().HasData(
                new { AccountId = 1, Title = "VK", Login = "74958004020", Password = "qwerty12345", NoteText = "Account for work" },
                new { AccountId = 2, Title = "GMAIL", Login = "example@gmail.com", Password = "qwerty12345", NoteText = "Mail for work" },
                new { AccountId = 3, Title = "mail.ru", Login = "example@mail.ru", Password = "qwerty12345", NoteText = "Main mail" },
                new { AccountId = 4, Title = "steam", Login = "steamlogin", Password = "qwerty12345", NoteText = "Games main account" },
                new { AccountId = 5, Title = "aliexpress", Login = "74958004020", Password = "qwerty12345", NoteText = "" }
                );
        }
    }
}
