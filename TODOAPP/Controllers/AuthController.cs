using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TODOAPP.Core.Implementations;
using TODOAPP.Core.Interfaces;
using TODOAPP.Domain.Models;

namespace TODOAPP.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        
        [HttpPost]
        public async Task<IActionResult> LoginAsync(LoginModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Username) 
                || string.IsNullOrWhiteSpace(model.Password))
            {
                return BadRequest();
            }

            var result = await _authService.LoginAsync(model);

            return result.IsSuccess switch
            {
                false when string.IsNullOrEmpty(result.Token) && string.IsNullOrEmpty(result.Message) =>
                    new StatusCodeResult(500),
                false => Unauthorized(result.Message),
                _ => Ok(new {data = result})
            };
        }
    }
}