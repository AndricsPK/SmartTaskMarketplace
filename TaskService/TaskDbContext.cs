using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TaskService.Models;

namespace TaskService
{
    public class TaskDbContext : DbContext
    {
        public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options) { }

        public DbSet<TaskItem> Tasks { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskItem>().HasData(
                new TaskItem { Id = 1, Title = "Design a logo", Description = "Need a logo for my startup", Status = "Open", ClientId = "1", FreelancerId = null },
                new TaskItem { Id = 2, Title = "Fix website bug", Description = "CSS issues on homepage", Status = "In Progress", ClientId = "2", FreelancerId = "3" }
            );
        }

    }

}
