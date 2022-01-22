using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TODOAPP.Core.Interfaces;
using TODOAPP.Domain.Entities;
using TODOAPP.Domain.Enums;

namespace TODOAPP.Domain.Contexts
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<TODOTask> TodoTasks { get; set; }
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new List<User>()
            {
                new User()
                {
                    Id = 1,
                    Username = "test.user",
                    Email = "test@user.com",
                    Role = Role.Basic,
                    PasswordHash = "26396FC8C5F9C45A3E6BD38A4CFD1120126CE4E938B00F5FF559A740C260791E" // T3stU$3r0!
                }
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}