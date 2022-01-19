using Microsoft.EntityFrameworkCore;

namespace TODOAPP.Domain.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {}
    }
}