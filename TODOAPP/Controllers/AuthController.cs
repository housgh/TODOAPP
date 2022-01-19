using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TODOAPP.Core.Implementations;
using TODOAPP.Domain.Models;

namespace TODOAPP.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }
        
        [HttpPost]
        public async Task<IActionResult> Index(LoginModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Username) 
                || string.IsNullOrWhiteSpace(model.Password))
            {
                return BadRequest();
            }

            var result = await _authService.LoginAsync(model);

            if (!result.IsSuccess || string.IsNullOrEmpty(result.Token))
            {
                return new StatusCodeResult(500);
            }

            return Ok(new {data = result});
        }
    }
}