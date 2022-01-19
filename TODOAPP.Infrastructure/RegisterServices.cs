using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TODOAPP.Core.Interfaces;
using TODOAPP.Domain.Contexts;

namespace TODOAPP.Infrastructure
{
    public static class RegisterServices
    {
        public static void RegisterInfrastructureServices(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer("Server=.;Database=TODOAPP;User Id=sa;Password=sql123;"));

            services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());
        }
    }
}