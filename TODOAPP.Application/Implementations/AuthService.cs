using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TODOAPP.Core.Interfaces;
using TODOAPP.Domain.Models;

namespace TODOAPP.Core.Implementations
{
    public class AuthService: IAuthService
    {
        private readonly IHashService _hashService;
        private readonly IApplicationDbContext _context;
        private readonly ITokenService _tokenService;

        public AuthService(
            IHashService hashService, 
            IApplicationDbContext context,
            ITokenService tokenService)
        {
            _hashService = hashService;
            _context = context;
            _tokenService = tokenService;
        }
        
        public async Task<LoginResult> LoginAsync(LoginModel model)
        {
            var passwordHash = _hashService.HashString(model.Password, model.Username);

            var user = await _context.Users.FirstOrDefaultAsync(user =>
                user.Username == model.Username && user.PasswordHash == passwordHash);

            if (user == null)
            {
                return new LoginResult()
                {
                    IsSuccess = false,
                    Message = "Invalid Username or Password"
                };
            }

            var token = _tokenService.GenerateToken(user);

            return new LoginResult()
            {
                IsSuccess = true,
                Token = token
            };
        }
    }
}