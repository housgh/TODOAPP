using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TODOAPP.Domain.Models;

namespace TODOAPP.Core.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<TODOTask> TodoTasks { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default (CancellationToken));
    }
}