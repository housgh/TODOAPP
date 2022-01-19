using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TODOAPP.Core.Interfaces;
using TODOAPP.Domain.Models;

namespace TODOAPP.Domain.Contexts
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<TODOTask> TodoTasks { get; set; }
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}
    }
}