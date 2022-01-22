using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using TODOAPP.Core.Interfaces;
using TODOAPP.Domain.Entities;
using TODOAPP.Domain.Models;

namespace TODOAPP.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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
            try
            {
                var entityExists = _taskRepository.Exists(t => t.Id == task.Id);

                if (!entityExists)
                {
                    return BadRequest();
                }

                await _taskRepository.UpdateAsync(task);
                return NoContent();
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(TODOTask task)
        {
            var currentUser = HttpContext.User;
            var isValid = int.TryParse(currentUser.FindFirst(ClaimTypes.NameIdentifier)?.Value, out var userId);

            if (!isValid) return Unauthorized();

            task.UserId = userId;
            task.CreatedOn = DateTime.Now;
            
            await _taskRepository.AddAsync(task);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
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