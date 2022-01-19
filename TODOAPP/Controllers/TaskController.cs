using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TODOAPP.Core.Interfaces;
using TODOAPP.Domain.Models;

namespace TODOAPP.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly IRepository<TODOTask> _taskRepository;

        public TaskController(IRepository<TODOTask> taskRepository)
        {
            _taskRepository = taskRepository;
        }
        
        [HttpGet]
        public IActionResult GetAsync()
        {
            var currentUser = HttpContext.User;
            var isValid = int.TryParse(currentUser.FindFirst(ClaimTypes.NameIdentifier)?.Value, out var userId);

            if (!isValid)
            {
                return Unauthorized();
            }

            var result = _taskRepository.Find(task => task.UserId == userId);
            return Ok(new {data = result});
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await _taskRepository.GetAsync(id);

            if (result == null)
            {
                return NotFound(id);
            }
            
            return Ok(new {data = result});
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(TODOTask task)
        {
            var entityExists = _taskRepository.Exists(t => t.Id == task.Id);

            if (!entityExists)
            {
                return BadRequest();
            }

            await _taskRepository.UpdateAsync(task);
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(TODOTask task)
        {
            await _taskRepository.AddAsync(task);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var entityExists = _taskRepository.Exists(t => t.Id == id);

            if (!entityExists)
            {
                return NotFound(id);
            }

            await _taskRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}