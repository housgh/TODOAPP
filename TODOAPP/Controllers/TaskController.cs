using Microsoft.AspNetCore.Mvc;

namespace TODOAPP.Controllers
{
    public class TaskController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}