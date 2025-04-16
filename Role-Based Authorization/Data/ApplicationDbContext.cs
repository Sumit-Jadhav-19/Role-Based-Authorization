using Microsoft.EntityFrameworkCore;
using Role_Based_Authorization.Models;

namespace Role_Based_Authorization.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; } // DbSet for User entity

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed data
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Username = "admin", Password = "admin123", Role = "Admin" },
                new User { Id = 2, Username = "user", Password = "user123", Role = "User" }
            );
        }
    }
}
