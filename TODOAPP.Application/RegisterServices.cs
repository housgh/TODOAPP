using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using TODOAPP.Core.Implementations;
using TODOAPP.Core.Interfaces;

namespace TODOAPP.Core
{
    public static class RegisterServices
    {
        public static void RegisterApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IHashService, HashService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            
                        
            services.AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(x =>
                {
                    x.TokenValidationParameters = new TokenValidationParameters    
                    {    
                        ValidateIssuer = true,    
                        ValidateAudience = true,    
                        ValidateLifetime = true,    
                        ValidateIssuerSigningKey = true,    
                        ValidIssuer = "TODOAPP-ISSUER",    
                        ValidAudience = "TODOAPP-AUDIENCE",    
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("**T0DO@PP_$3CR3T_K3Y**"))    
                    }; 
                });
        }
    }
}