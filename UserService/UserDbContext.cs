using Microsoft.EntityFrameworkCore;
using UserService.Models;

namespace UserService
{

        public class UserDbContext : DbContext
        {
            public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }

            public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Username = "alice", Email = "alice@example.com", Role = "client", Bio = "Startup founder" },
                new User { Id = 2, Username = "bob", Email = "bob@example.com", Role = "client", Bio = "Tech blogger" },
                new User { Id = 3, Username = "carol", Email = "carol@example.com", Role = "freelancer", Bio = "Full-stack developer" }
            );
        }

    }

}
