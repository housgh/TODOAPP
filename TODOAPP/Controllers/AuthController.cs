using Microsoft.AspNetCore.Mvc;

namespace TODOAPP.Controllers
{
    public class Auth : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}