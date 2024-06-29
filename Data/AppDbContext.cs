using Microsoft.EntityFrameworkCore;
using pLocals.Controllers;
using pLocals.Models;
using System.Reflection.Metadata;

namespace pLocals.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
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
                .Property(a => a.NormalizedTitle)
                .IsRequired();
            modelBuilder.Entity<Account>()
                .Property(a => a.Login)
                .IsRequired();
            modelBuilder.Entity<Account>()
                .Property(a => a.Password)
                .IsRequired();

            modelBuilder.Entity<Account>().HasData(
                new { Id = 1, Title = "VK", NormalizedTitle = "vk", Login = "74958004020", Password = "qwerty12345", NoteText = "Account for work" },
                new { Id = 2, Title = "GMAIL", NormalizedTitle = "gmail", Login = "example@gmail.com", Password = "qwerty12345", NoteText = "Mail for work" },
                new { Id = 3, Title = "mail.ru", NormalizedTitle = "mail.ru", Login = "example@mail.ru", Password = "qwerty12345", NoteText = "Main mail" },
                new { Id = 4, Title = "steam", NormalizedTitle = "steam", Login = "steamlogin", Password = "qwerty12345", NoteText = "Games main account" },
                new { Id = 5, Title = "aliexpress", NormalizedTitle = "aliexpress", Login = "74958004020", Password = "qwerty12345", NoteText = "" }
                );
        }
    }
}
